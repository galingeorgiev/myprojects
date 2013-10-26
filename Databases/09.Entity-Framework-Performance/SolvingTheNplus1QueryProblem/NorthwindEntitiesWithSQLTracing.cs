using System;
using UsingEntityFrameworkModel;
using System.IO;
using EFProviderWrapperToolkit;
using EFTracingProvider;

class NorthwindEntitiesWithSQLTracing : NorthwindEntities
{
	private TextWriter logOutput;

    public NorthwindEntitiesWithSQLTracing() : this("name=NorthwindEntities")
    {
    }

    public NorthwindEntitiesWithSQLTracing(string connectionString)
        : base(EntityConnectionWrapperUtils.CreateEntityConnectionWithWrappers(
                connectionString, "EFTracingProvider"))
    {
    }

    private EFTracingConnection TracingConnection
    {
        get { return this.UnwrapConnection<EFTracingConnection>(); }
    }

    public event EventHandler<CommandExecutionEventArgs> CommandExecuting
    {
        add { this.TracingConnection.CommandExecuting += value; }
        remove { this.TracingConnection.CommandExecuting -= value; }
    }

    public event EventHandler<CommandExecutionEventArgs> CommandFinished
    {
        add { this.TracingConnection.CommandFinished += value; }
        remove { this.TracingConnection.CommandFinished -= value; }
    }

    public event EventHandler<CommandExecutionEventArgs> CommandFailed
    {
        add { this.TracingConnection.CommandFailed += value; }
        remove { this.TracingConnection.CommandFailed -= value; }
    }

    private void AppendToLog(object sender, CommandExecutionEventArgs e)
    {
        if (this.logOutput != null)
        {
            this.logOutput.WriteLine(e.ToTraceString().TrimEnd());
            this.logOutput.WriteLine();
        }
    }

    public TextWriter Log
    {
        get { return this.logOutput; }
        set
        {
            if ((this.logOutput != null) != (value != null))
            {
                if (value == null)
                {
                    CommandExecuting -= AppendToLog;
                }
                else
                {
                    CommandExecuting += AppendToLog;
                }
            }

            this.logOutput = value;
        }
    }
}
