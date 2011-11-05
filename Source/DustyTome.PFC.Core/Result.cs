using System;
using System.Collections.Generic;
using System.Text;

namespace DustyTome.PFC.Core
{
    public class Result : IResult
    {
        private IEnumerable<string> _errorMessages;
        private EnumerableHelper _enumerableHelper;

        public Result(IEnumerable<string> errorMessages)
            : this(errorMessages, new EnumerableHelper())
        { }

        public Result(IEnumerable<string> errorMessages, EnumerableHelper enumerableHelper)
        {
            _errorMessages = errorMessages;
            _enumerableHelper = enumerableHelper;
        }

        public bool HasErrors
        {
            get { return _enumerableHelper.NumberOfItemsIn(_errorMessages) > 0; }
        }

        public IEnumerable<string> GetErrorMessages()
        {
            return _errorMessages;
        }
    }
}
