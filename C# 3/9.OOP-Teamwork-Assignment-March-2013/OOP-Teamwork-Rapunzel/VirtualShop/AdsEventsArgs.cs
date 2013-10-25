using System;

public class AdsEventArgs : EventArgs
{
    private string companyName;
    private string adsContent;

    public AdsEventArgs(string companyName, string adsContent)
    {
        this.companyName = companyName;
        this.adsContent = adsContent;
    }

    public string CompanyName
    {
        get { return this.companyName; }
    }

    public string AdsContent
    {
        get { return this.adsContent; }
    }
}
