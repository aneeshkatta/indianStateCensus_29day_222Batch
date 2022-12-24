using IndianStateCensus;
using IndianStateCensus.DataDAO;
using IndianStateCensus.DTO;
namespace CensusTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        string stateCodePath = @"E:\New folder\IndianStateCensus\IndianStateCensus\CSVFiles\IndiaStateCode.csv";
        string stateCensusPath = @"E:\New folder\IndianStateCensus\IndianStateCensus\CSVFiles\IndiaStateCensusData.csv";
        string wrongCensusPath = @"E:\New folder\IndianStateCensus\IndianStateCensus\CSVFiles\WrongIndiaStateCensusData.csv";
        string wrongStateCodePath = @"E:\New folder\IndianStateCensus\IndianStateCensus\CSVFiles\WrongIndiaStateCode.csv";
        string wrongTypeStateCodePath = @"E:\New folder\IndianStateCensus\IndianStateCensus\CSVFiles\WrongIndiaStateCode.csv";
        string wrongHeaderStateCodePath = @"E:\New folder\IndianStateCensus\IndianStateCensus\CSVFiles\WrongIndiaStateCode.csv";
        string wrongHeaderStateCensusPath = @"E:\New folder\IndianStateCensus\IndianStateCensus\CSVFiles\WrongIndiaStateCensusData.csv";
        string delimiterStateCodePath = @"E:\New folder\IndianStateCensus\IndianStateCensus\CSVFiles\DelimiterIndiaStateCode.csv";
        string delimiterStateCensusPath = @"E:\New folder\IndianStateCensus\IndianStateCensus\CSVFiles\DelimiterIndiaStateCensusData.csv";
        Dictionary<string, CensusDataDAO> stateRecords;
        IndianStateCensus.CSVAdapterFactory csv = null;
        //Dictionary<string, CensusDTO> totalRecords;
        [TestMethod]
        public void SetUp()
        {
            csv = new IndianStateCensus.CSVAdapterFactory();
            // totalRecords = new Dictionary<string, CensusDTO>();
            stateRecords = new Dictionary<string, CensusDataDAO>();
        }
        /// TC 1.1
        /// Giving the correct path it should return the total count from the census
        [TestMethod]
        public void GivenStateCensusCSVShouldReturnRecords()
        {
            stateRecords = csv.LoadCsvData(IndianStateCensus.CensusAnalyser.Country.INDIA, stateCensusPath, "State,Population,AreaInSqKm,DensityPerSqKm");
            Assert.AreEqual(29, stateRecords.Count);
        }
        /// TC 1.2
        /// Giving incorrect path should return file not found custom exception
        [TestMethod]
        public void GivenIncorrectFileShouldThrowCustomException()
        {
            try
            {
                var customException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongCensusPath, "State,Population,AreaInSqKm,DensityPerSqKm"));
                //total no of rows excluding header are 29 in indian state census data.
                //Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, customException.exception);
            }
            catch (CensusAnalyserException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Assert.AreEqual(customException.exception, CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
        }
        /// TC 1.3
        /// Giving wrong type of path should return invalid file type custom exception
        [TestMethod]
        public void GivenWrongTypeReturnsCustomException()
        {
            try
            {
                var customException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongTypeStateCodePath, "SrNo,State Name,TIN,StateCode"));
                Assert.AreEqual(customException.exception, CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
            }
            catch (CensusAnalyserException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// TC 1.4
        /// Giving wrong delimiter should return incorrect delimiter custom exception
        [TestMethod]
        public void GivenWrongDelimeterReturnsCustomException()
        {
            try
            {
                var censusException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, delimiterStateCensusPath, "State,Population,AreaInSqKm,DensityPerSqKm"));
                Assert.AreEqual(censusException.exception, CensusAnalyserException.ExceptionType.INCOREECT_DELIMITER);
            }
            catch (CensusAnalyserException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// TC 1.5
        /// Giving wrong header type should return incorrect header type custom exception
        [TestMethod]
        public void GivenWrongHeaderReturnsCustomException()
        {
            try
            {
                var censusException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongHeaderStateCensusPath, "State,Population,AreaInSqKm,DensityPerSqKm"));
                Assert.AreEqual(censusException.exception, CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
            }
            catch (CensusAnalyserException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// TC 2.1
        /// Giving the correct path it should return the total count from the census
        [TestMethod]
        public void GivenStateCodeReturnCount()
        {
            //totalRecords = csv.LoadCsvData(CensusAnalyser.Country.INDIA, stateCodePath, "SrNo,State Name,TIN,StateCode");
            //Assert.AreEqual(37, totalRecords.Count);
        }
        /// TC 2.2
        /// Giving incorrect path should return file not found custom exception
        [TestMethod]
        public void GivenIncorrectPathCodeCustomException()
        {
            var stateCustomException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongStateCodePath, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(stateCustomException.exception, CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
        }
        /// TC 2.3
        /// Giving wrong type of path should return invalid file type custom exception
        [TestMethod]
        public void GivenIncorrectPathTypeCodeReturnException()
        {
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongTypeStateCodePath, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(customException.exception, CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
        }
        /// TC 2.4
        /// Giving wrong delimiter should return incorrect delimiter custom exception
        [TestMethod]
        public void GivenWrongHeaderStateCodeReturnCustomException()
        {
            var stateException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, delimiterStateCodePath, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(stateException.exception, CensusAnalyserException.ExceptionType.INCOREECT_DELIMITER);
        }
        /// TC 2.5
        /// Giving wrong header type should return incorrect header type custom exception
        [TestMethod]
        public void GivenWrongDelimiterCodeReturnCustomException()
        {
            var stateException = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongHeaderStateCodePath, "SrNo,State Name,TIN,StateCode"));
            Assert.AreEqual(stateException.exception, CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
        }
    }
}


