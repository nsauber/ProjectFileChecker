using System;
using System.Collections.Generic;
using System.Text;

namespace DustyTome.PFC.Core
{
    public class FileResults : IFileResults
    {
        private readonly EnumerableHelper _enumerableHelper;
        private readonly IFile _file;
        private readonly IList<IError> _errorMessages;
        
        public FileResults(IFile file)
            : this(file, new EnumerableHelper())
        { }
        public FileResults(IFile file, EnumerableHelper enumerableHelper)
        {
            _enumerableHelper = enumerableHelper;
            _file = file;

            _errorMessages = new List<IError>();
        }

        public IFile File
        {
            get { return _file; }
        }

        public string FilePath
        {
            get { return _file.FilePath; }
        }

        public bool HasErrors
        {
            get { return _enumerableHelper.NumberOfItemsIn(_errorMessages) > 0; }
        }

        public IEnumerable<IError> GetErrors()
        {
            return _errorMessages;
        }

        public void Merge(IEnumerable<IError> errors)
        {
            foreach(var error in errors)
            {
                _errorMessages.Add(error);
            }
        }
    }
}
