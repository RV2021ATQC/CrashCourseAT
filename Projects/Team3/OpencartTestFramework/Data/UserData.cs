
namespace OpencartTestFramework.Data
{
    class UserData
    {
        public UserData()
        {

        }
        public UserData(string _userName, string _apiToken)
        {
            this.userName = _userName;
            this.apiToken = _apiToken;
        }
        public string userName { get; set; } = "Default";
        public string apiToken { get; set; } = 
            "KdkzNAXmWtp1fu94gzC45ZLfvTLVCyvjUv0tku0zL2ka6SCsPQNHNG9uQTw1FYX0smb0xktn" +
            "NcQYmz6rGEkaTwsWL8YRlwzYPFqLZUTfhasX0i9Wtgqb7XY3rP9zVaxY1QfT3Irbfxr5chF1T73mDd8GHOMqu8f31lpXmHFAqroau2xpqOa" +
            "8UEOLUIIGSRY9uIXRW4drWndbrOTHqReiFo94cm4jdwUXlfIPTrKzckOKRbd9WBL40B1sk2tDwMvA";
    }
}

