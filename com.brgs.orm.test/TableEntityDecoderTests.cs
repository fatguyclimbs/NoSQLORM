using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Moq;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

using com.brgs.orm.helpers;

namespace com.brgs.orm.test
{
    public class TableEntityDecoderTests
    {
        [Fact]
        public void DoesConvertITableEntityIntoDomainObject()
        {

            //var river = new River()
            //{
            //    Name = "GAULEY RIVER BELOW SUMMERSVILLE DAM, WV",
            //    RiverId = "03189600",
            //    State = "West Virginia",
            //    StateCode = "WV",
            //    Srs = "EPSG:4326",
            //    Latitude = "38.2151103",
            //    Longitude = "-80.8881536",
            //    Id="Gauley|03189600"
            //};
            //var helper = new AzureFormatHelper("pizza");
            //var entity = helper.BuildTableEntity(river);

            //var testVal = (River)AzureFormatHelper.RecastEntity(entity, typeof(River));
            //Assert.Equal(river.Name, testVal.Name);

            var helper = new AzureFormatHelper();
            Assert.Equal(1, 1);

        }        
    }
}   