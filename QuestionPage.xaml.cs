namespace mobileapp;

public partial class QuestionPage : ContentPage
{
	public QuestionPage()
	{
		InitializeComponent();
	}

    private void GetQuestionButtonClicked(object sender, EventArgs e)
    {
		var questions = Constants.QUESTION_AT_RANDOM;
    }
}