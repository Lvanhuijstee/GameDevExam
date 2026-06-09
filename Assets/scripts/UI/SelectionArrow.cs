using UnityEngine;
using UnityEngine.UI;

public class SelectionArrow : MonoBehaviour
{
    [SerializeField] private RectTransform[] options;
    private RectTransform rect;
    private int currentPos;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        // changing arrow position with w/s or up/down arrows
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            changePosition(-1);
        } else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            changePosition(1);
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) {
            select();
        }
    }

    private void select() { 
        options[currentPos].GetComponent<Button>().onClick.Invoke();
    }

    private void changePosition(int _change) {
        currentPos += _change;
        

        if(currentPos < 0) {
            currentPos = options.Length - 1;
        } else if (currentPos > options.Length -1) {
            currentPos = 0;
        }
        rect.position = new Vector3(rect.position.x, options[currentPos].position.y, 0);

    }
}
