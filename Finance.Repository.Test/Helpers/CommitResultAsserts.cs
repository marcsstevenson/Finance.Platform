using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Framework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Finance.Repository.Test.Helpers
{
    public static class CommitResultAsserts
    {
        public static Exception GetInnerMostException(this CommitResult commitResult)
        {
            if (commitResult.Error == null) return null;

            var error = commitResult.Error;

            while (error.InnerException != null)
                error = error.InnerException;

            return error;
        }
        public static string GetInnerMostExceptionMessage(this CommitResult commitResult)
        {
            if (commitResult.Error == null) return null;

            var innerMostException = commitResult.GetInnerMostException();

            return innerMostException?.Message;
        }

        public static void AssertNoError(this CommitResult commitResult)
        {
            Assert.IsNull(commitResult.Error, commitResult.GetInnerMostExceptionMessage());
        }
    }
}
