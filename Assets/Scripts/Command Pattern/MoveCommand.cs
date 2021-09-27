using Yashlan.player;

public class MoveCommand : Command
{
    PlayerMovement playerMovement;
    float h, v;

    public MoveCommand(PlayerMovement playerMovement, float h, float v)
    {
        this.playerMovement = playerMovement;
        this.h = h;
        this.v = v;
    }

    //Trigger perintah movement
    public override void Execute()
    {
        playerMovement.Move(h, v);
        //Menganimasikan player
        playerMovement.Animating(h, v);
    }

    public override void UnExecute()
    {
        //Invers arah dari movement player
        playerMovement.Move(-h, -v);
        //Menganimasikan player
        playerMovement.Animating(h, v);
    }
}
