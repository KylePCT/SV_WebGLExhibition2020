using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class FeedbackCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtData_name;
    [SerializeField] private TextMeshProUGUI txtData_query;
    [SerializeField] private TextMeshProUGUI txtData_phone;
    [SerializeField] private TextMeshProUGUI txtData_email;
    [SerializeField] private UnityEngine.UI.Button btnSubmit;
    [SerializeField] private CollectionOption option;

    private enum CollectionOption { openEmailClient, openGFormLink, sendGFormData };

    //E-Mail input for feedback.
    private const string kReceiverEmailAddress = "info@sonovision.co.uk";

    //Google forms input.
    private const string kGFormBaseURL = "https://docs.google.com/forms/d/e/1FAIpQLSfSJPxytxPToIr-46lrtz-WkrLHyS9NCbq4RBLV4onBoj3owA/";
    //private const string kGFormEntryID = "entry.1330939643";

    private const string inputName = "entry.388515623";
    private const string inputQuery = "entry.167127794";
    private const string inputNumber = "entry.1486152578";
    private const string inputEmail = "entry.1105577395";

    void Start()
    {
        //Make sure it isn't null.
        UnityEngine.Assertions.Assert.IsNotNull(txtData_name);
        UnityEngine.Assertions.Assert.IsNotNull(txtData_query);
        UnityEngine.Assertions.Assert.IsNotNull(txtData_phone);
        UnityEngine.Assertions.Assert.IsNotNull(txtData_email);
        UnityEngine.Assertions.Assert.IsNotNull(btnSubmit);

        btnSubmit.onClick.AddListener(delegate
        {
            Debug.Log("Added listener to button.");
            //Allows the user to select multiple ways of collecting feedback.
            switch (option)
            {
                case CollectionOption.openEmailClient:
                    OpenEmailClient(txtData_name.text);
                    OpenEmailClient(txtData_query.text);
                    OpenEmailClient(txtData_phone.text);
                    OpenEmailClient(txtData_email.text);
                    break;
                case CollectionOption.openGFormLink:
                    OpenGFormLink();
                    break;
                case CollectionOption.sendGFormData:
                    StartCoroutine(SendGFormData(txtData_name.text));
                    Debug.Log("Name: <" + txtData_name.text + "> sent.");
                    StartCoroutine(SendGFormData(txtData_query.text));
                    Debug.Log("Query: <" + txtData_query.text + "> sent.");
                    StartCoroutine(SendGFormData(txtData_phone.text));
                    Debug.Log("Phone: <" + txtData_phone.text + "> sent.");
                    StartCoroutine(SendGFormData(txtData_email.text));
                    Debug.Log("E-mail: <" + txtData_email.text + "> sent.");
                    break;
            }
        });
    }

    //E-mail method. Sets the email as the one above, and populates the e-mail.
    private static void OpenEmailClient(string feedback)
    {
        string email = kReceiverEmailAddress;
        string subject = "Feedback";
        string body = "<" + feedback + ">";
        OpenLink("mailto:" + email + "?subject=" + subject + "&body=" + body);
    }

    //We cannot have spaces in links for iOS
    public static void OpenLink(string link)
    {
        bool googleSearch = link.Contains("google.com/search");
        string linkNoSpaces = link.Replace(" ", googleSearch ? "+" : "%20");
        Application.OpenURL(linkNoSpaces);
    }

    //Form method opens the form.
    private static void OpenGFormLink()
    {
        string urlGFormView = kGFormBaseURL + "viewform";
        OpenLink(urlGFormView);
    }

    //Form data is then converted to JSON and sent to the server utilising the BaseURL.
    private static IEnumerator SendGFormData<T>(T dataContainer)
    {
        bool isString = dataContainer is string;
        string jsonData = isString ? dataContainer.ToString() : JsonUtility.ToJson(dataContainer);

        WWWForm form = new WWWForm();
        form.AddField(inputName, jsonData);
        form.AddField(inputQuery, jsonData);
        form.AddField(inputNumber, jsonData);
        form.AddField(inputEmail, jsonData);
        string urlGFormResponse = kGFormBaseURL + "formResponse";
        using (UnityWebRequest www = UnityWebRequest.Post(urlGFormResponse, form))
        {
            yield return www.SendWebRequest();
        }
    }
}