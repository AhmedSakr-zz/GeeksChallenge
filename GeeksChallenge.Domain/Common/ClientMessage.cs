using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GeeksChallenge.Domain.Enums;

namespace GeeksChallenge.Domain.Common
{
   public class ClientMessage<T>
    {
        public ClientMessage()
        {
        }

        public ClientMessage(AppEnums.OperationStatus statusCode, List<string> message, List<ValidationResult> validationResults, T data)
        {
            _statusCode = statusCode;
            _message = message;
            _validationResults = validationResults;
            _data = data;
        }

        private AppEnums.OperationStatus _statusCode;
        public AppEnums.OperationStatus ClientStatusCode
        {
            get { return _statusCode; }
            set { _statusCode = value; }
        }

        private List<string> _message = new List<string>();
        public List<string> ClientMessageContent
        {
            get { return _message; }
            set { _message = value; }
        }


        private List<ValidationResult> _validationResults = new List<ValidationResult>();
        public List<ValidationResult> ValidationResults
        {
            get { return _validationResults; }
            set { _validationResults = value; }
        }

        private T _data;

        public T ReturnedData
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }
    }
}

            
