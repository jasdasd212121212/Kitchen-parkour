public class PlayerActiveState : State
{
    private PlayerJumper _player;
    private JumpInput _input;
    private PlayerHealth _health;

    public PlayerActiveState(PlayerJumper player, JumpInput input, PlayerHealth health)
    {
        _input = input;
        _player = player;
        _health = health;
    }

    public override void Entry()
    {
        _input.enabled = true;
        _player.enabled = true;
        _health.enabled = true;
    }

    public override void Exit()
    {
        _input.enabled = false;
        _player.enabled = false;
        _health.enabled = false;
    }
}