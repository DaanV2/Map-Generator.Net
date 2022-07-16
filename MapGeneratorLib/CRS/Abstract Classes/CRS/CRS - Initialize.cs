namespace Map.CRS {

    public abstract partial class CRS {
        public CRS(Transformation trans) {
            this.Transformation = trans;
        }
    }
}
