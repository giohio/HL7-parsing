using System;
using System.Diagnostics;
using NHapi.Base.Parser;
using NHapi.Model.V23.Message;

namespace HapiParserBasicOperations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string messageString = "MSH|^~\\&|SendingAPP|TEST|||20080617143943||ORU^R01|1|P|2.3.1||||||UNICODE\r\n" +
                                        "PID|1||7393670^^^^MR||Joan^JIang||19900804000000|Female PV1|1||nk^^001\r\n" + "OBR|1||20071207011|00001^AutomatedCount^99MRC||20080508140600|20080508150616|||John||||20080508150000||||||||||HM||||||||TEST";

            // instantiate a PipeParser, which handles the "traditional or default encoding"
            var ourPipeParser = new PipeParser();

            try
            {
                // parse the string format message into a Java message object
                var hl7Message = ourPipeParser.Parse(messageString);

                

                // Display the updated HL7 message using Pipe delimited format
                LogToDebugConsole("HL7 Pipe Delimited Message Output:");
                LogToDebugConsole(ourPipeParser.Encode(hl7Message));

                // instantiate an XML parser that NHAPI provides
                var ourXmlParser = new DefaultXMLParser();

                // convert from default encoded message into XML format, and send it to standard out for display
                LogToDebugConsole("HL7 XML Formatted Message Output:");
                LogToDebugConsole(ourXmlParser.Encode(hl7Message));

            }
            catch (Exception e)
            {
                LogToDebugConsole($"Error occured -> {e.StackTrace}");
            }
        }

        private static void LogToDebugConsole(string informationToLog)
        {
            Debug.WriteLine(informationToLog);
        }
    }
}