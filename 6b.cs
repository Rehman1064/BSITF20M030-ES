using System;

interface ITextCommand
{
    void Execute();
}

class CopyCommand : ITextCommand
{
    private readonly TextEditingTool textEditingTool;

    public CopyCommand(TextEditingTool textEditingTool)
    {
        this.textEditingTool = textEditingTool;
    }

    public void Execute()
    {
        textEditingTool.Copy();
    }
}

class PasteCommand : ITextCommand
{
    private readonly TextEditingTool textEditingTool;

    public PasteCommand(TextEditingTool textEditingTool)
    {
        this.textEditingTool = textEditingTool;
    }

    public void Execute()
    {
        textEditingTool.Paste();
    }
}

class TextEditingTool
{
    private string clipboard;

    public void Copy()
    {
        clipboard = "Text copied to clipboard.";
        Console.WriteLine(clipboard);
    }

    public void Paste()
    {
        Console.WriteLine($"Text pasted: {clipboard}");
    }
}

class TextEditorUser
{
    private ITextCommand textCommand;

    public void SetTextCommand(ITextCommand command)
    {
        this.textCommand = command;
    }

    public void ExecuteTextAction()
    {
        textCommand.Execute();
    }
}

class Program
{
    static void Main()
    {
        var textEditingTool = new TextEditingTool();

        var copyCommand = new CopyCommand(textEditingTool);
        var pasteCommand = new PasteCommand(textEditingTool);

        var textEditorUser = new TextEditorUser();

        textEditorUser.SetTextCommand(copyCommand);
        textEditorUser.ExecuteTextAction();

        textEditorUser.SetTextCommand(pasteCommand);
        textEditorUser.ExecuteTextAction();
    }
}
