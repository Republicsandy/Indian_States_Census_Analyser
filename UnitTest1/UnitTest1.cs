using NUnit.Framework;

using IndianStatesCensusAnalyser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IndianCensusProject
{
    [TestClass]
    public class UnitTest1
    {
        CensusAdapter censusAdapter;
        string censusFilePath = @"E:\Bridgelabz\C_#_Mssql_Programes_and_Projects\Indian_States_Census_Analyser\IndianStatesCensusAnalyser\IndianStateCensusInformation.csv";
        string invalidFileCsvPath = @"E:\Bridgelabz\C_#_Mssql_Programes_and_Projects\Indian_States_Census_Analyser\IndianStatesCensusAnalyser\InvalidCensusFile.csv";
        [TestInitialize]
        public void SetUp()
        {
            censusAdapter = new CensusAdapter();
        }
        //TC1.1:Given the States Census CSV file, Check to ensure the Number of Record matches
        [TestMethod]
        [TestCategory("Given the States Census CSV file, Check to ensure the Number of Record matches")]
        public void TestMethodToCheckCountOfDataRetrieved()
        {
            //Excluding Header
            int expected = 28;
            string[] result = censusAdapter.GetCensusData(censusFilePath, "State,Population,Increase,Area(Km2),Density,Sex-Ratio,Literacy");
            int actual = result.Length - 1;
            Assert.AreEqual(expected, actual);
        }
        //TC1.2:Given the State Census CSV File if incorrect Returns a custom Exception
        [TestMethod]
        [TestCategory("Invalid File Name")]
        public void TestMethodToCheckInvalidFileName()
        {
            try
            {
                censusAdapter.GetCensusData(invalidFileCsvPath, "State,Population,Increase,Area(Km2),Density,Sex-Ratio,Literacy");

            }
            catch (CensusCustomException ex)
            {
                Assert.AreEqual(ex.Message, "File not found!");
            }
        }
    }
}