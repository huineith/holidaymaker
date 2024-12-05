namespace app.Classes;

public class BedXRoom
{
    
    public int RoomId; 
    public int BedTypeId; 
    public int Amount;

    
    public BedXRoom(int roomId, int bedTypeId, int amount)
    {
        RoomId = roomId;
        BedTypeId = bedTypeId;
        Amount = amount;
    }
}