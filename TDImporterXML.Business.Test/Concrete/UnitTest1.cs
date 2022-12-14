using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDImporterXML.Business.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDImporterXML.Business.Abstract;
using TDImporterXML.Entities;

namespace TDImporterXML.Business.Concrete.Tests
{
    [TestClass()]
    public class UnitTest1
    {
        private readonly IFirmsService _firmsService;

        public UnitTest1(IFirmsService firmsService)
        {
            _firmsService = firmsService;
        }

        public void GetAllFirmsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddFirmTest()
        {
            int firmNr = 18;
            bool isDefault = true;
            

        }
    }
}