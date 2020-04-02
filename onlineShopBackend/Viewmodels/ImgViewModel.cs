using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using onlineShopBackend.Models;

/// <summary>  
/// Image view model class.  
/// </summary>  
public class ImgViewModel
{
    #region Properties  

    /// <summary>  
    /// Gets or sets Image file.  
    /// </summary>  
    [Required]
    [Display(Name = "Upload File")]
    public HttpPostedFileBase FileAttach { get; set; }

    /// <summary>  
    /// Gets or sets Image file list.  
    /// </summary>  
    public List<categoryImage> ImgLst { get; set; }

    #endregion
}