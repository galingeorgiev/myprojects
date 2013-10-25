using System.Windows.Forms;

class AnnonymousMethods
{
    delegate void SomeDelegate(string str);

    private void ShowMsg(string msg)
    {
        MessageBox.Show(msg);
    }

    public void InvokeDelegate()
    {
        SomeDelegate d = ShowMsg;
        d("I am called by a delegate.");
    }

    public void InvokeAnnonymousMethod()
    {
        SomeDelegate d = delegate(string str)
        {
            MessageBox.Show(str);
        };
        d("I am called by an annonymous method.");
    }

    public void InvokeLambdaFunction()
    {
        SomeDelegate d = (str) =>
        {
            MessageBox.Show(str);
        };
        d("I am called by a lambda function.");
    }

    static void Main()
    {
        AnnonymousMethods example = new AnnonymousMethods();
        example.InvokeDelegate();
        example.InvokeAnnonymousMethod();
        example.InvokeLambdaFunction();
    }
}
