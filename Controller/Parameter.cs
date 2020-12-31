namespace Controller {
    public class Parameter {
        public string ParameterName { get; set; }
        public string ParameterType { get; set; }
        public object Value { get; set; }
        
        public Parameter() {}
        
        
        public Parameter(string parameterName, string parameterType, object value) {
            ParameterName = parameterName;
            ParameterType = parameterType;
            Value = value;
        }
    }
}