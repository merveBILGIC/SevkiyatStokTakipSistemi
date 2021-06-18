using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SevkiyatStokTakipSistemi.Enums
{
    public enum Roles
    {
        /// <summary>
        /// SuperAdmin rolu yönetici
        /// </summary>
        
        yönetici,

        /// <summary>
        /// Admin rolu sipariş 
        /// </summary>
        siparis,

        /// <summary>
        /// Moderator rolu sevkiyat
        /// </summary>
        sevkiyat, 

        /// <summary>
        /// Basic rolu güvenlik
        /// </summary>
        güvenlik
    }
}
