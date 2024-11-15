namespace Restaurant.Core.Entities.Base
{

    public abstract class BaseEntity<TId>
    {
        public virtual TId Id { get; protected set; }

        public DateTime CreatedAt { get; protected set; }

        public int CreatedByUserId { get; protected set; }

        public DateTime? UpdatedAt { get; protected set; }

        public int? UpdatedByUserId { get; protected set; }

        int? _requestedHashCode;

        public bool IsTransient()
        {
            return Id.Equals(default(TId));
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is BaseEntity<TId>))
                return false;

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (GetType() != obj.GetType())
            {
                return false;
            }

            var item = (BaseEntity<TId>)obj;

            if (item.IsTransient() || IsTransient())
                return false;
            else
                return item == this;
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = Id.GetHashCode() ^ 31;

                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();
        }

        public static bool operator ==(BaseEntity<TId> left, BaseEntity<TId> right)
        {
            if (Equals(left, null))
                return Equals(right, null) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(BaseEntity<TId> left, BaseEntity<TId> right)
        {
            return !(left == right);
        }

        public void SetCreatedByUserId(int createdByUserId)
        {
            CreatedByUserId = createdByUserId;
        }

        public void SetCreatedAt(DateTime createdAt)
        {
            CreatedAt = createdAt;
        }

        public void SetUpdatedByUserId(int? createdByUserId)
        {
            UpdatedByUserId = createdByUserId;
        }

        public void SetUpdatedAt(DateTime? updatedAt)
        {
            UpdatedAt = updatedAt;
        }

    }
}
