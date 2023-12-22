using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WXWork3rd.Data;

public class TCorp
{
    [StringLength(32)]
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
}

