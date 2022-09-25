using codeBase.game.player;

namespace codeBase.game.ball
{
    public interface IPlayerControlable
    {
        public void beginControl(Player player);
        public void control(float horizontalAxis, float verticalAxis);
        public void endControl(Player player);
        public ControlType controlType();
    }

    public enum ControlType
    {
        AllAxis,
        Horizontal
    }
}