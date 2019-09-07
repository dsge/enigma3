
using Godot;

namespace App.Inventory
{
    public interface InventoryItemInterface {
    }
    /**
     * an item in the game that can do at least one of the following:
     * - be picked up from the ground
     * - be dropped down to the ground
     * - be put in the player's inventory
     * - be consumed/used
     */
    public class InventoryItem: InventoryItemInterface {



        public string displayName = "<unnamed item>";
        public Texture inventoryNodeTexture = null;
        public Vector2? inventoryNodeCellSize;
        public int stackCount = 1;
        public int maxStackCount = 1;
        protected InventoryNode _inventoryNode = null;
        protected MeshInstance _groundNode = null;

        public InventoryItem(Texture texture, Vector2? gridCellSize = null) : base() {
            this.inventoryNodeTexture = texture;
            this.inventoryNodeCellSize = gridCellSize;
        }

        public InventoryNode getInventoryNode() {
            if (this._inventoryNode == null) {
                this._inventoryNode = new InventoryNode(this.inventoryNodeTexture, this.inventoryNodeCellSize);
                this._inventoryNode.item = this;
            }
            return this._inventoryNode;
        }

        public MeshInstance getGroundNode() {
            if (this._groundNode == null) {
                this._groundNode = (MeshInstance)((GD.Load<PackedScene>("res://scenes/item-on-ground.tscn")).Instance());
            }
            return this._groundNode;
        }
    }
}
