using System;

namespace DDDSample1.Domain.Shared {
    public interface IValidator {
        public bool IsValid(params Object[] parameters);
    }
}