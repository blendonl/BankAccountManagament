namespace BankAccountManagament {
    public class Property {
        public string PropertyName { get; set; }
        public string PropertyType { get; set; }
        public object PropertyValue { get; set; }

        public Property() { }

        public Property(string propertyName, string propertyType, object propertyValue) {
            PropertyName = propertyName;
            PropertyType = propertyType;
            PropertyValue = propertyValue;
        }
    }
}