namespace ContactManager;

internal interface IContactManager
{
    void AddContact();
    void DisplayContacts();
    void SearchContact();
    void SaveToFile(string filePath);
    void LoadFromFile(string filePath);
}
