﻿
class User
{
    private string _logedUser = "";
    private string _logedPassword = "";

    public string logedUser
    {
        get {
            return _logedUser;
        }
    }

    public bool login(string number, string password)
    {
        _logedUser = "";
        _logedPassword = "";

        Connection conn = Connection.getInstance();
        MessageFactory messageFactory = MessageFactory.getInstance();
        string message = messageFactory.loginMessage(number, password);
        string response = conn.sendMessage(message);

        ServerResponse serverResponse = new ServerResponse(response);
        if (serverResponse.getType() == "login")
        {
            if (serverResponse.getParams()["result"] == "success")
            {
                _logedUser = number;
                _logedPassword = password;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}