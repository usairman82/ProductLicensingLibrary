using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
//ToDo: Implement the Encryption Key Retrieval Process such
//That if any parts are bypassed the code breaks.
namespace CWActivationLibrary
{
    /// <summary>
    /// The purpose of this class is to provide a framework for activating
    /// software, and controlling access to specific areas of the software
    /// durring the trial period of the software.
    /// 
    /// The use of this library will currently be limited to applications developed under .NET
    /// 
    /// </summary>
     public enum PeriodType
    {
        DAYS,
        MONTHS,
        HOURS,
        ACTIVATIONS
    };

     public enum ControlType
    {
        ALLOW,
        DENY,
        RESTRICT
    };

    [Serializable()]
     public class CWActivation:ISerializable 
    {
         private String                      m_PackageName;           //The name of the product being protected.
         private Int32                       m_TrialPeriod;           //Period of trial. in Days, Months,Years, Or Activations.
         private PeriodType                  m_TrialPeriodType;       //What is the trial period type.
         private List<String>                m_ControlledObjects;     //<String Form Name, Bool IsControlled
		 private ControlType				 m_ControlType;			  //This determines what manner of control each form has. 
         private DateTime                    m_TrialBeginDate;        //
         private DateTime                    m_TrialEndDate;          //
         private Int32                       m_ActivationCount;       //
         private bool                        m_ProductIsActivated;    //Only Set When The Product Key Is Verified.
         private String                      m_ProductActivationCode; //The Product Activation Code.
         private bool                        m_PreviouslyInitilized;
		 private String						 m_PublicKeyString;		  //The Public Key Used To Decode License Keys
		 private String						 m_MachineName;			  //The Name Of The Machine When Activated.
		//Need to figure out an alternative method of tieing a public Key to the application.
        public CWActivation (SerializationInfo info, StreamingContext ctxt)
        {
			String	m_TempMachineName		= System.Environment.MachineName;
					m_PackageName           = (String)info.GetValue("PackageName",				typeof(String      )	  );
					m_TrialPeriod           = (Int32)info.GetValue("TrialPeriod",				typeof(Int32       )	  );
					m_TrialPeriodType       = (PeriodType)info.GetValue("PeriodType",			typeof(PeriodType  )      );     //What is the trial period type.
					m_ControlledObjects     = (List<String>)info.GetValue("ControlledObjects",	typeof(List<String>)      );     //<String Form Name, Bool IsControlled
					m_ControlType			= (ControlType)info.GetValue("ControlType",			typeof(ControlType )	  );
					m_TrialBeginDate        = (DateTime)info.GetValue("TrialBeginDate",			typeof(DateTime    )      );     //
					m_TrialEndDate          = (DateTime)info.GetValue("TrialEndDate",			typeof(DateTime    )      );     //
					m_ActivationCount       = (Int32)info.GetValue("ActivationCount",			typeof(Int32       )      );     //
					m_ProductIsActivated    = (bool)info.GetValue("ProductIsActivated",			typeof(bool        )      );     //Only Set When The Product Key Is Verified.
					m_ProductActivationCode = (String)info.GetValue("ProductActivationCode",	typeof(String      )      );     //The Product Activation Code.
					m_PreviouslyInitilized  = (bool)info.GetValue("PreviouslyInitilized",		typeof(bool        )      );
					m_PublicKeyString       = (String)info.GetValue("PublicKeyString",			typeof(String      )      );
					m_MachineName			= (String)info.GetValue("MachineName",				typeof(String      )      );
			++m_ActivationCount;

			if (m_ProductIsActivated && m_MachineName.Length > 0)
			{
				//If Some one has attempted to move the application from one machine
				//to another.  De-Activate, and Terminate the trial period.
				if (m_TempMachineName != m_MachineName)
				{
					m_ProductIsActivated = false;
					m_TrialEndDate = DateTime.Now;
					m_ProductActivationCode = "XXXXX-XXXXX-XXXXX-XXXXX-XXXXX-XXXXX";
					m_TrialPeriod           = 0;
					m_TrialBeginDate  = DateTime.Now;
					m_TrialPeriodType = PeriodType.DAYS;
				}
			}
			//If this is the first time the object has been instantiated
			//since it was initilize in the control panel
			//ensure that it sets the begin date of the trial period to now.
			if (m_PreviouslyInitilized == false)
			{
				m_TrialBeginDate			= DateTime.Now;
				m_PreviouslyInitilized		= true;
			}
		}
        

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            //You can use any custom name for your name-value pair. But make sure you

            // read the values with the same name. For ex:- If you write EmpId as "EmployeeId"

            // then you should read the same with "EmployeeId"

            info.AddValue("PackageName",            m_PackageName			);
            info.AddValue("TrialPeriod",            m_TrialPeriod			);
            info.AddValue("PeriodType",             m_TrialPeriodType		);			//What is the trial period type.
            info.AddValue("ControlledObjects",      m_ControlledObjects		);			//<String Form Name, Bool IsControlled
            info.AddValue("ControlType",			m_ControlType			);
			info.AddValue("TrialBeginDate",         m_TrialBeginDate		);			//
            info.AddValue("TrialEndDate",           m_TrialEndDate			);          //
            info.AddValue("ActivationCount",        m_ActivationCount		);			//
            info.AddValue("ProductIsActivated",     m_ProductIsActivated	);			//Only Set When The Product Key Is Verified.
            info.AddValue("ProductActivationCode",  m_ProductActivationCode	);			//The Product Activation Code.
            info.AddValue("PreviouslyInitilized",   m_PreviouslyInitilized	);
			info.AddValue("PublicKeyString",        m_PublicKeyString       );
			info.AddValue("MachineName",			m_MachineName			);
		}

        #region "Constructors"
        /// <summary>
        /// No Arg. Constructor.
        /// </summary>
        public CWActivation()
        {
            //Load Data From The DLL which is being used to hide the serialized object.
           m_ControlledObjects= new List<String>();
           InitilizeMemberData();
        }

        public void InitControlledObjects(List<String> lObjectsToControl)
        {
            m_ControlledObjects = lObjectsToControl;
        }

        private void InitilizeMemberData()
        {
            m_ProductIsActivated	= false;
            m_ProductActivationCode = "";
            m_PreviouslyInitilized	= false;
			m_ControlType			= ControlType.ALLOW; 
			m_PublicKeyString		= "";
			m_ProductActivationCode = "XXXXX-XXXXX-XXXXX-XXXXX-XXXXX-XXXXX"; //Initilize the value so that the changes in file size will be more minute.
			m_MachineName			= "";
        }

        #endregion

        #region "Public Properties"

		public String MachineName
		{
			get
			{
				return m_MachineName;
			}
			set
			{
				m_MachineName = value;
			}
		}
        public bool   HasPreviouslyBeenInitilized
        {
            get
            {
                return m_PreviouslyInitilized;
            }
        }
        public bool   IsProductActivated
        {
            get
            {
                return m_ProductIsActivated;
            }
        }

        public String ProductActivationCode
        {
            set
            {
                m_ProductActivationCode = value;
            }
        }

        public String PackageName
        {
            get
            {
                return m_PackageName;
            }
            set
            {
                m_PackageName = value;
            }
        }

        public Int32 TrialPeriod
        {
            get
            {
                return m_TrialPeriod;
            }
            set
            {
                m_TrialPeriod = value;
            }
        }

        public PeriodType TrialPeriodType
        {
            get
            {
                return m_TrialPeriodType;
            }
            set
            {
                m_TrialPeriodType = value;
            }
        }

        public DateTime TrialBeginDate
        {
            get
            {
                return m_TrialBeginDate;
            }
            set
            {
                m_TrialBeginDate = value;
            }
        }

		public ControlType ObjectsControlType
		{
			set
			{
				this.m_ControlType = value;
			}
		}

        public DateTime TrialEndDate
        {
            get
            {
                return m_TrialEndDate;
            }
            set
            {
                m_TrialEndDate = value;
            }
        }

        /// <summary>
        ///Property for accessing the Activation Count.
        /// </summary>
        public Int32 ActivationCount
        {
            get
            {
                return m_ActivationCount;
            }
            set
            {
                m_ActivationCount = value;
            }
        }
       #endregion

        #region "Public Methods"
        public bool IsObjectControlled(String sObjectName)
        {
           if (m_ControlledObjects.Contains(sObjectName))
           {
               return true;
           }
           else
           {
               return false;
           }
        }

		/// <summary>
		/// Add the name of an object that is to be controlled by the activation class.
		/// </summary>
		/// <param name="sObjectName"></param>
         public void AddControlledObject(String sObjectName) //,ControlType cType)
        {
            m_ControlledObjects.Add(sObjectName);
        }

        /// <summary>
        /// Test to see if the current time marks the end of the trial period
        /// </summary>
        /// <returns></returns>
         public bool HasTrialPeriodElapsed()
        {
            if (m_TrialPeriodType == PeriodType.DAYS || m_TrialPeriodType == PeriodType.HOURS || m_TrialPeriodType == PeriodType.MONTHS)
            {
                DateTime currentDateTime = DateTime.Now;
				CalculateEndDate();

                return (currentDateTime >= m_TrialEndDate);
            }
            else if (m_TrialPeriodType == PeriodType.ACTIVATIONS)
            {
                return (m_ActivationCount >= m_TrialPeriod);
            }
            return true;    //If we got here something is very wrong.  Assume a cracking attempt and lock the software
        }

		/// <summary>
		/// Figure out the end date based off of the trial period criteria.
		/// </summary>
		private void CalculateEndDate()
		{
			switch (m_TrialPeriodType)
			{
				case PeriodType.DAYS:
					m_TrialEndDate = m_TrialBeginDate.AddDays(m_TrialPeriod);
					break;
				case PeriodType.HOURS:
					m_TrialEndDate = m_TrialBeginDate.AddHours(m_TrialPeriod);
					break;
				case PeriodType.MONTHS:
					m_TrialEndDate = m_TrialBeginDate.AddMonths(m_TrialPeriod);
					break;
			}
		}
        /// <summary>
        /// Called to verify whether the activation code is valid or not.
		/// Takes the users information (First Name, Last Name, Telephone Number, and Email_
		/// Calculated What The Key Should Be Then Tests it Against The Key Generated.
        /// </summary>
        /// <returns></returns>
        public bool VerifyActivationCode(String sData)
        {
			bool testResults = false;
			//int  resFacorial = 0,interFact = 1;
			testResults = Test(sData);
            //Call Some Private Method To Perform The Validation
            //Or Call Our Proprietary Non .NET Code Verification Library.
			//if (!())
			//{
			//    for (int i = 1; i < sData.Length;i++)
			//    {
			//        for (j = 1;j < i;j++)
			//        {
			//            interFact += interFact*j;
			//        }
			//        resFactorial+=interFact;
			//        interFact = 1;
			//    }
			//}
			return testResults;
        }

		//Call the calculation procedure
		private bool Test(String data)
		{
			return Calculate(data);
		}
        #endregion

        #region "Private Methods"

		/// <summary>
		/// Calculate value to determine the state of
		/// ProductIsActivated.
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		private bool Calculate(String data)
		{
			if (m_ProductActivationCode.Length > 0)
			{
				 
				{
					CWActivationKeyGenerator tempCalculator = new CWActivationKeyGenerator();
					String testCalculatedValues = tempCalculator.GenerateActivationKey(data);
					if (testCalculatedValues == m_ProductActivationCode)
					{
					    this.m_MachineName		= System.Environment.MachineName.ToString();
						m_ProductIsActivated	= true;
					}
					else
					{
						m_ProductIsActivated = false;
					}

				}
				GC.Collect();
			}
			else
			{
				m_ProductIsActivated = false;
			}

			return m_ProductIsActivated;
		}

        /// <summary>
        /// Calculates the end date of the trial period.
        /// Used when the TrialPeriodType is a DAY,MONTH,or YEAR type.
        /// </summary>
        /// <returns></returns
         private DateTime CalulateTrialEndDate()
        {
            return DateTime.Now;
        }
        #endregion



    }
}
