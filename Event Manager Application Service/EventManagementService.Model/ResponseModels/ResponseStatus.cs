namespace EventManagementService.Model.ResponseModels
{
    public class ResponseStatus
    {
        public ResponseStatus(ResponseCode responseCode, string responseMessage, Object? dataSet)
        {
            ResponseCode = responseCode;
            ResponseMessage = responseMessage;
            DataSet = dataSet;
        }

        public ResponseCode ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public object? DataSet { get; set; }
    }
}