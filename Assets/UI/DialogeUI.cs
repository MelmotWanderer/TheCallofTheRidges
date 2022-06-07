
using UnityEngine;
using UnityEngine.UI;

public class DialogeUI : UI
{

    [SerializeField] private Image _background;
    [SerializeField] private TextWriter textWriter;
    [SerializeField] private Image completing;
    [SerializeField] private Button[] _answersPlayer;
    [SerializeField] private Text _name;
    [SerializeField] private Text _interactMessage;
    private Text[] _answersPlayerText;
    private Saying _saying;
    private int currentIndexText = 0;
    private Animator _animator;
    private bool isInteractiveDialogue;
    private InteractiveDialoge currentNPCDialogue;
    private SoundWriting _soundWriting;
    protected override void Init()
    {
       
        ActiveInteractMessage(false);
        _answersPlayerText = new Text[3];
        for (int i = 0; i != _answersPlayer.Length; i++)
        {
            _answersPlayerText[i] = _answersPlayer[i].GetComponentInChildren<Text>();
        }
        _animator = _background.GetComponent<Animator>();
       
    }


    private void Update()
    {
        if (textWriter.isComplete)
        {
            bool isSayingWithAnswers = TrySetAnswerPlayer();
            if (!isSayingWithAnswers) {

                completing.enabled = true;
            }
            SetActiveButtonAnswerPlayer(isSayingWithAnswers);
            if (!isInteractiveDialogue && Input.GetButtonDown("Next"))
            {
                SwitchSaying(currentIndexText + 1);
            }

        }
    }
    public void SetDialogueNPC(InteractiveDialoge dialoge)
    {
        currentNPCDialogue = dialoge;
    }
    public void SetWritingSound(SoundWriting soundWriting)
    {
        _soundWriting = soundWriting;
    }
    public void Up()
    {
        completing.enabled = false;

        _animator.SetBool("Up", true);

        SwitchSaying(currentIndexText);
    }
    public void Down()
    {
        textWriter.Stop();
        CleanAnswers();
        currentIndexText = 0;
        _animator.SetBool("Up", false);
    }
    public void SetName(string name)
    {
        _name.text = name;
     
    }
    public void SwitchSaying(int indexSaying)
    {
        
        _saying = currentNPCDialogue.SwitchSaying(indexSaying);
        currentIndexText = indexSaying; 
        WriteSaying();
    }
    public void SetInteractMessage(string name)
    {
        _interactMessage.text = "Нажмите на кнопку разговора, чтобы начать говорить с " + name;
    }
    public void ActiveInteractMessage(bool isActive)
    {
        _interactMessage.enabled = isActive;
    }
    private bool TrySetAnswerPlayer()
    {
        if (_saying.Answers.Length != 0)
        {
            
            isInteractiveDialogue = true;
            for (int i = 0; i != _saying.Answers.Length; i++)
            {
                int index = i;
                _answersPlayerText[index].text = _saying.Answers[index].Text;

                _answersPlayer[index].onClick.RemoveAllListeners();
                _answersPlayer[index].onClick.AddListener(delegate { SwitchSaying(_saying.Answers[index].TransitionIndex); });


            }
            return true;
        }
        return false;
    }
    private void SetActiveButtonAnswerPlayer(bool active)
    {
        for (int i = 0; i != _saying.Answers.Length; i++)
        {
            int index = i;
            _answersPlayer[index].enabled = active;

            


        }
    }
    private void WriteSaying()
    {
        completing.enabled = false;
        isInteractiveDialogue = false;
        CleanAnswers();
        textWriter.Stop();
        textWriter.WriteText(_saying.Text, _soundWriting);
    }
    
    private void CleanAnswers()
    {
        foreach(Text text in _answersPlayerText)
        {
            text.text = "";
        }
    }

    
}
