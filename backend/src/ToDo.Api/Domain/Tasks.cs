namespace ToDo.Api.Domain;

public class Tasks : Audit
{
    public Tasks()
    {
        Title = string.Empty;
        Description = string.Empty;
        IsDone = false;
    }

    public Tasks(string title, string description, bool isDone)
    {
        Title = title;
        Description = description;
        IsDone = isDone;
    }

    public string Title { get; private set; } 
    public string Description { get; private set; } 
    public bool IsDone { get; private set; } 

    public void UpdateObject(string title, string description, bool isDone)
    {
        Title = title;
        Description = description;
        IsDone = isDone;
    }
   
}
