using codeBase.game.player;

namespace codeBase.game.ball
{
    public interface IControlable
    {
        public void beginControl(Player player);
        public void control(float horizontalAxis, float verticalAxis);
        public void endControl(Player player);
    }
}