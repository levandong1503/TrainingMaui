using TrainingMaui.Utils.Containts;

namespace TrainingMaui.UI;

public class ChatDataTemplateSelector : DataTemplateSelector
{
    public DataTemplate MySelfChat { get; set; } = null!;
    public DataTemplate YouChat { get; set; } = null!;
    public DataTemplate TimeChat { get; set; } = null!;
    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        if(item is not null)
        {
            var chatObject = (ChatObject)item
                .GetType()
                ?.GetProperty("ChatObject")
                ?.GetValue(item);
            return chatObject switch
            {
                ChatObject.MySelf => MySelfChat,
                ChatObject.You => YouChat,
                ChatObject.Time => TimeChat,
                _ => throw new ArgumentOutOfRangeException(nameof(chatObject), chatObject, null)
            };
        }

        throw new Exception("item not founding in ChatDataTemplate");
    }
}
