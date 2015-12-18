using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelControl.Storage
{
    public class StorageInMemory : IStorage
    {
        private static readonly object _syncRoot = new object();
        private static List<RouteEntity> _routeEntities;

        #region Connection functions
        public IEnumerable<ConnectionEntity> GetAllConnections()
        {
            return new List<ConnectionEntity>()
            {
                { new ConnectionEntity { From = "asdm", To = "dmn" } },
                { new ConnectionEntity { From = "dmn", To = "wp" } },
                { new ConnectionEntity { From = "wp", To = "almm" } },
                { new ConnectionEntity { From = "almm", To = "alm" } },
                { new ConnectionEntity { From = "alm", To = "almp" } },
                { new ConnectionEntity { From = "almp", To = "almb" } },
                { new ConnectionEntity { From = "almb", To = "lls" } },
                { new ConnectionEntity { From = "laa", To = "vbl" } },
                { new ConnectionEntity { From = "ldv", To = "vbl" } },
                { new ConnectionEntity { From = "ldv", To = "pnk" } },
                { new ConnectionEntity { From = "rdr", To = "pnk" } },
                { new ConnectionEntity { From = "rdr", To = "rtwp" } },
                { new ConnectionEntity { From = "rtkw", To = "rtwp" } },
                { new ConnectionEntity { From = "rtkw", To = "rtbw" } },
                { new ConnectionEntity { From = "rth", To = "rtbw" } },
                { new ConnectionEntity { From = "ldv", To = "ztmv" } },
                { new ConnectionEntity { From = "ztmv", To = "ztmcw" } },
                { new ConnectionEntity { From = "ztmv", To = "ztmb" } },
                { new ConnectionEntity { From = "ztmv", To = "ztmm" } },
                { new ConnectionEntity { From = "ztmm", To = "dmp" } },
                { new ConnectionEntity { From = "dmp", To = "dtwa" } },
                { new ConnectionEntity { From = "dtwa", To = "ztmd" } },
                { new ConnectionEntity { From = "ztmd", To = "ztmcw" } },
                { new ConnectionEntity { From = "ztmcw", To = "zsh" } },
                { new ConnectionEntity { From = "zsh", To = "ztmp" } },
                { new ConnectionEntity { From = "ztmp", To = "ztms" } },
                { new ConnectionEntity { From = "ztms", To = "ztml" } },
                { new ConnectionEntity { From = "ztml", To = "ley" } },
                { new ConnectionEntity { From = "ley", To = "ztmb" } },
                { new ConnectionEntity { From = "vb", To = "ztm" } },
                { new ConnectionEntity { From = "vb", To = "gv" } },
                { new ConnectionEntity { From = "ztm", To = "ztmo" } },
                { new ConnectionEntity { From = "gd", To = "ztmo" } },
                { new ConnectionEntity { From = "amf", To = "bnn" } },
                { new ConnectionEntity { From = "apd", To = "bnn" } },
                { new ConnectionEntity { From = "bnn", To = "bnc" } },
                { new ConnectionEntity { From = "ltn", To = "bnc" } },
                { new ConnectionEntity { From = "ltn", To = "edc" } },
                { new ConnectionEntity { From = "ed", To = "edc" } },
                { new ConnectionEntity { From = "apd", To = "dv" } },
                { new ConnectionEntity { From = "es", To = "hgl" } },
                { new ConnectionEntity { From = "amf", To = "amfs" } },
                { new ConnectionEntity { From = "bgn", To = "rsd" } },
                { new ConnectionEntity { From = "rtb", To = "rtd" } },
                { new ConnectionEntity { From = "rtd", To = "sdm" } },
                { new ConnectionEntity { From = "gv", To = "laa" } },
                { new ConnectionEntity { From = "hfd", To = "nvp" } },
                { new ConnectionEntity { From = "ledn", To = "nvp" } },
                { new ConnectionEntity { From = "asdl", To = "shl" } },
                { new ConnectionEntity { From = "asdl", To = "asdv" } },
                { new ConnectionEntity { From = "ass", To = "asdv" } },
                { new ConnectionEntity { From = "asd", To = "ass" } },
                { new ConnectionEntity { From = "vs", To = "vss" } },
                { new ConnectionEntity { From = "mdb", To = "vss" } },
                { new ConnectionEntity { From = "arn", To = "mdb" } },
                { new ConnectionEntity { From = "arn", To = "gs" } },
                { new ConnectionEntity { From = "bzl", To = "gs" } },
                { new ConnectionEntity { From = "bzl", To = "krg" } },
                { new ConnectionEntity { From = "kbd", To = "krg" } },
                { new ConnectionEntity { From = "kbd", To = "rb" } },
                { new ConnectionEntity { From = "bgn", To = "rb" } },
                { new ConnectionEntity { From = "bd", To = "tb" } },
                { new ConnectionEntity { From = "ac", To = "bkl" } },
                { new ConnectionEntity { From = "ac", To = "asb" } },
                { new ConnectionEntity { From = "utl", To = "utm" } },
                { new ConnectionEntity { From = "hor", To = "utm" } },
                { new ConnectionEntity { From = "bkl", To = "mas" } },
                { new ConnectionEntity { From = "mas", To = "ut" } },
                { new ConnectionEntity { From = "bnk", To = "ut" } },
                { new ConnectionEntity { From = "bnk", To = "db" } },
                { new ConnectionEntity { From = "db", To = "mrn" } },
                { new ConnectionEntity { From = "mrn", To = "vndw" } },
                { new ConnectionEntity { From = "vndc", To = "vndw" } },
                { new ConnectionEntity { From = "rhn", To = "vndc" } },
                { new ConnectionEntity { From = "ehb", To = "ehv" } },
                { new ConnectionEntity { From = "bet", To = "ehb" } },
                { new ConnectionEntity { From = "bet", To = "btl" } },
                { new ConnectionEntity { From = "btl", To = "vg" } },
                { new ConnectionEntity { From = "ht", To = "vg" } },
                { new ConnectionEntity { From = "asn", To = "gn" } },
                { new ConnectionEntity { From = "zl", To = "wz" } },
                { new ConnectionEntity { From = "wz", To = "hde" } },
                { new ConnectionEntity { From = "hde", To = "ns" } },
                { new ConnectionEntity { From = "ns", To = "hd" } },
                { new ConnectionEntity { From = "hd", To = "eml" } },
                { new ConnectionEntity { From = "eml", To = "pt" } },
                { new ConnectionEntity { From = "pt", To = "nkk" } },
                { new ConnectionEntity { From = "nkk", To = "amfs" } },
                { new ConnectionEntity { From = "hgv", To = "mp" } },
                { new ConnectionEntity { From = "mp", To = "zl" } },
                { new ConnectionEntity { From = "bl", To = "hgv" } },
                { new ConnectionEntity { From = "asn", To = "bl" } },
                { new ConnectionEntity { From = "lls", To = "zl" } },
                { new ConnectionEntity { From = "asdz", To = "shl" } },
                { new ConnectionEntity { From = "asa", To = "asd" } },
                { new ConnectionEntity { From = "ass", To = "zd" } },
                { new ConnectionEntity { From = "cas", To = "hlo" } },
                { new ConnectionEntity { From = "amr", To = "hlo" } },
                { new ConnectionEntity { From = "amr", To = "amrn" } },
                { new ConnectionEntity { From = "amrn", To = "hwd" } },
                { new ConnectionEntity { From = "hwd", To = "sgn" } },
                { new ConnectionEntity { From = "ehv", To = "gp" } },
                { new ConnectionEntity { From = "gp", To = "hze" } },
                { new ConnectionEntity { From = "hze", To = "wt" } },
                { new ConnectionEntity { From = "rm", To = "wt" } },
                { new ConnectionEntity { From = "asa", To = "dvd" } },
                { new ConnectionEntity { From = "hdr", To = "hdrz" } },
                { new ConnectionEntity { From = "ana", To = "hdrz" } },
                { new ConnectionEntity { From = "ana", To = "sgn" } },
                { new ConnectionEntity { From = "asa", To = "asb" } },
                { new ConnectionEntity { From = "asb", To = "dvd" } },
                { new ConnectionEntity { From = "hn", To = "hnk" } },
                { new ConnectionEntity { From = "hks", To = "hnk" } },
                { new ConnectionEntity { From = "bkg", To = "hks" } },
                { new ConnectionEntity { From = "bkf", To = "bkg" } },
                { new ConnectionEntity { From = "bkf", To = "ekz" } },
                { new ConnectionEntity { From = "hn", To = "obd" } },
                { new ConnectionEntity { From = "hwd", To = "obd" } },
                { new ConnectionEntity { From = "gv", To = "gvc" } },
                { new ConnectionEntity { From = "ehv", To = "hmh" } },
                { new ConnectionEntity { From = "hmh", To = "hm" } },
                { new ConnectionEntity { From = "hmbh", To = "hm" } },
                { new ConnectionEntity { From = "dn", To = "hmbh" } },
                { new ConnectionEntity { From = "dn", To = "hrt" } },
                { new ConnectionEntity { From = "br", To = "hrt" } },
                { new ConnectionEntity { From = "br", To = "vl" } },
                { new ConnectionEntity { From = "had", To = "hlm" } },
                { new ConnectionEntity { From = "ass", To = "hlm" } },
                { new ConnectionEntity { From = "ddr", To = "ddzd" } },
                { new ConnectionEntity { From = "ddzd", To = "zlw" } },
                { new ConnectionEntity { From = "zlw", To = "zvb" } },
                { new ConnectionEntity { From = "odb", To = "zvb" } },
                { new ConnectionEntity { From = "odb", To = "rsd" } },
                { new ConnectionEntity { From = "cas", To = "utg" } },
                { new ConnectionEntity { From = "ed", To = "klp" } },
                { new ConnectionEntity { From = "ah", To = "est" } },
                { new ConnectionEntity { From = "est", To = "nm" } },
                { new ConnectionEntity { From = "nm", To = "nmd" } },
                { new ConnectionEntity { From = "nmd", To = "wc" } },
                { new ConnectionEntity { From = "wc", To = "rvs" } },
                { new ConnectionEntity { From = "rvs", To = "o" } },
                { new ConnectionEntity { From = "o", To = "ow" } },
                { new ConnectionEntity { From = "ow", To = "rs" } },
                { new ConnectionEntity { From = "rs", To = "hto" } },
                { new ConnectionEntity { From = "hto", To = "ht" } },
                { new ConnectionEntity { From = "nm", To = "nmh" } },
                { new ConnectionEntity { From = "nmh", To = "ck" } },
                { new ConnectionEntity { From = "ck", To = "bmr" } },
                { new ConnectionEntity { From = "bmr", To = "vlb" } },
                { new ConnectionEntity { From = "vlb", To = "vry" } },
                { new ConnectionEntity { From = "vry", To = "br" } },
                { new ConnectionEntity { From = "hn", To = "pmo" } },
                { new ConnectionEntity { From = "hfd", To = "shl" } },
                { new ConnectionEntity { From = "zp", To = "vd" } },
                { new ConnectionEntity { From = "vd", To = "rl" } },
                { new ConnectionEntity { From = "rl", To = "ltv" } },
                { new ConnectionEntity { From = "ltv", To = "ww" } },
                { new ConnectionEntity { From = "dv", To = "zp" } },
                { new ConnectionEntity { From = "dv", To = "ost" } },
                { new ConnectionEntity { From = "ost", To = "wh" } },
                { new ConnectionEntity { From = "wh", To = "zl" } },
                { new ConnectionEntity { From = "bd", To = "etn" } },
                { new ConnectionEntity { From = "etn", To = "rsd" } },
                { new ConnectionEntity { From = "rh", To = "dr" } },
                { new ConnectionEntity { From = "rh", To = "ahpr" } },
                { new ConnectionEntity { From = "ahp", To = "ahpr" } },
                { new ConnectionEntity { From = "ahp", To = "ah" } },
                { new ConnectionEntity { From = "ahp", To = "dvn" } },
                { new ConnectionEntity { From = "dvn", To = "zv" } },
                { new ConnectionEntity { From = "zv", To = "did" } },
                { new ConnectionEntity { From = "did", To = "wl" } },
                { new ConnectionEntity { From = "wl", To = "dtch" } },
                { new ConnectionEntity { From = "dtch", To = "dtc" } },
                { new ConnectionEntity { From = "dtc", To = "tbg" } },
                { new ConnectionEntity { From = "tbg", To = "vsv" } },
                { new ConnectionEntity { From = "vsv", To = "atn" } },
                { new ConnectionEntity { From = "atn", To = "ww" } },
                { new ConnectionEntity { From = "bmn", To = "zp" } },
                { new ConnectionEntity { From = "kbk", To = "zp" } },
                { new ConnectionEntity { From = "kbk", To = "apd" } },
                { new ConnectionEntity { From = "dr", To = "bmn" } },
                { new ConnectionEntity { From = "kbw", To = "zd" } },
                { new ConnectionEntity { From = "kbw", To = "kzd" } },
                { new ConnectionEntity { From = "kzd", To = "wm" } },
                { new ConnectionEntity { From = "kma", To = "wm" } },
                { new ConnectionEntity { From = "kma", To = "utg" } },
                { new ConnectionEntity { From = "rtd", To = "rtn" } },
                { new ConnectionEntity { From = "rta", To = "rtn" } },
                { new ConnectionEntity { From = "cps", To = "rta" } },
                { new ConnectionEntity { From = "cps", To = "nwk" } },
                { new ConnectionEntity { From = "gd", To = "nwk" } },
                { new ConnectionEntity { From = "gd", To = "gdg" } },
                { new ConnectionEntity { From = "nwl", To = "sdm" } },
                { new ConnectionEntity { From = "nwl", To = "vdo" } },
                { new ConnectionEntity { From = "vdg", To = "vdo" } },
                { new ConnectionEntity { From = "vdg", To = "vdw" } },
                { new ConnectionEntity { From = "mss", To = "vdw" } },
                { new ConnectionEntity { From = "mss", To = "msw" } },
                { new ConnectionEntity { From = "hld", To = "msw" } },
                { new ConnectionEntity { From = "hld", To = "hlds" } },
                { new ConnectionEntity { From = "dmnz", To = "wp" } },
                { new ConnectionEntity { From = "dmnz", To = "dvd" } },
                { new ConnectionEntity { From = "dvd", To = "rai" } },
                { new ConnectionEntity { From = "asdz", To = "rai" } },
                { new ConnectionEntity { From = "hvs", To = "hvsp" } },
                { new ConnectionEntity { From = "ut", To = "uto" } },
                { new ConnectionEntity { From = "hvs", To = "hvsn" } },
                { new ConnectionEntity { From = "bsmz", To = "hvsn" } },
                { new ConnectionEntity { From = "bsmz", To = "ndb" } },
                { new ConnectionEntity { From = "ndb", To = "wp" } },
                { new ConnectionEntity { From = "dtz", To = "sdm" } },
                { new ConnectionEntity { From = "dt", To = "dtz" } },
                { new ConnectionEntity { From = "dt", To = "rsw" } },
                { new ConnectionEntity { From = "gvmw", To = "rsw" } },
                { new ConnectionEntity { From = "gv", To = "gvmw" } },
                { new ConnectionEntity { From = "ddr", To = "zwd" } },
                { new ConnectionEntity { From = "brd", To = "zwd" } },
                { new ConnectionEntity { From = "brd", To = "rlb" } },
                { new ConnectionEntity { From = "rlb", To = "rtz" } },
                { new ConnectionEntity { From = "rtb", To = "rtz" } },
                { new ConnectionEntity { From = "bd", To = "bdpb" } },
                { new ConnectionEntity { From = "bdpb", To = "zlw" } },
                { new ConnectionEntity { From = "ovn", To = "zvt" } },
                { new ConnectionEntity { From = "hlm", To = "ovn" } },
                { new ConnectionEntity { From = "brn", To = "sd" } },
                { new ConnectionEntity { From = "sd", To = "st" } },
                { new ConnectionEntity { From = "st", To = "stz" } },
                { new ConnectionEntity { From = "dld", To = "stz" } },
                { new ConnectionEntity { From = "bhv", To = "dld" } },
                { new ConnectionEntity { From = "bhv", To = "uto" } },
                { new ConnectionEntity { From = "amf", To = "dld" } },
                { new ConnectionEntity { From = "gvc", To = "laa" } },
                { new ConnectionEntity { From = "gvm", To = "laa" } },
                { new ConnectionEntity { From = "gvm", To = "vst" } },
                { new ConnectionEntity { From = "dvnk", To = "vst" } },
                { new ConnectionEntity { From = "dvnk", To = "ledn" } },
                { new ConnectionEntity { From = "ledn", To = "vh" } },
                { new ConnectionEntity { From = "hil", To = "vh" } },
                { new ConnectionEntity { From = "had", To = "hil" } },
                { new ConnectionEntity { From = "lut", To = "std" } },
                { new ConnectionEntity { From = "bk", To = "lut" } },
                { new ConnectionEntity { From = "bde", To = "bk" } },
                { new ConnectionEntity { From = "bde", To = "mt" } },
                { new ConnectionEntity { From = "mt", To = "mtr" } },
                { new ConnectionEntity { From = "edn", To = "mtr" } },
                { new ConnectionEntity { From = "ec", To = "rm" } },
                { new ConnectionEntity { From = "ec", To = "srn" } },
                { new ConnectionEntity { From = "srn", To = "std" } },
                { new ConnectionEntity { From = "gln", To = "std" } },
                { new ConnectionEntity { From = "gln", To = "sbk" } },
                { new ConnectionEntity { From = "sbk", To = "sn" } },
                { new ConnectionEntity { From = "nh", To = "sn" } },
                { new ConnectionEntity { From = "hb", To = "nh" } },
                { new ConnectionEntity { From = "hb", To = "hrl" } },
                { new ConnectionEntity { From = "dv", To = "dvc" } },
                { new ConnectionEntity { From = "dvc", To = "hon" } },
                { new ConnectionEntity { From = "hon", To = "rsn" } },
                { new ConnectionEntity { From = "rsn", To = "wdn" } },
                { new ConnectionEntity { From = "aml", To = "wdn" } },
                { new ConnectionEntity { From = "ah", To = "otb" } },
                { new ConnectionEntity { From = "otb", To = "wf" } },
                { new ConnectionEntity { From = "ed", To = "wf" } },
                { new ConnectionEntity { From = "bn", To = "hgl" } },
                { new ConnectionEntity { From = "amri", To = "bn" } },
                { new ConnectionEntity { From = "aml", To = "amri" } },
                { new ConnectionEntity { From = "nvd", To = "wdn" } },
                { new ConnectionEntity { From = "nvd", To = "rat" } },
                { new ConnectionEntity { From = "hno", To = "rat" } },
                { new ConnectionEntity { From = "hno", To = "zl" } },
                { new ConnectionEntity { From = "apn", To = "ldl" } },
                { new ConnectionEntity { From = "ldl", To = "ledn" } },
                { new ConnectionEntity { From = "ut", To = "vtn" } },
                { new ConnectionEntity { From = "vtn", To = "wd" } },
                { new ConnectionEntity { From = "bkl", To = "wd" } },
                { new ConnectionEntity { From = "bdg", To = "wd" } },
                { new ConnectionEntity { From = "apn", To = "bdg" } },
                { new ConnectionEntity { From = "akm", To = "hr" } },
                { new ConnectionEntity { From = "akm", To = "gw" } },
                { new ConnectionEntity { From = "gw", To = "lw" } },
                { new ConnectionEntity { From = "mp", To = "swk" } },
                { new ConnectionEntity { From = "swk", To = "wv" } },
                { new ConnectionEntity { From = "hr", To = "wv" } },
                { new ConnectionEntity { From = "gd", To = "wad" } },
                { new ConnectionEntity { From = "wad", To = "wadn" } },
                { new ConnectionEntity { From = "bsk", To = "wadn" } },
                { new ConnectionEntity { From = "apn", To = "bsk" } },
                { new ConnectionEntity { From = "dl", To = "zl" } },
                { new ConnectionEntity { From = "dl", To = "omn" } },
                { new ConnectionEntity { From = "hdb", To = "omn" } },
                { new ConnectionEntity { From = "co", To = "gbg" } },
                { new ConnectionEntity { From = "co", To = "dln" } },
                { new ConnectionEntity { From = "na", To = "dln" } },
                { new ConnectionEntity { From = "na", To = "emnb" } },
                { new ConnectionEntity { From = "emn", To = "emnb" } },
                { new ConnectionEntity { From = "gbg", To = "hdb" } },
                { new ConnectionEntity { From = "hk", To = "utg" } },
                { new ConnectionEntity { From = "bv", To = "hk" } },
                { new ConnectionEntity { From = "bv", To = "drh" } },
                { new ConnectionEntity { From = "drh", To = "sptn" } },
                { new ConnectionEntity { From = "sptn", To = "sptz" } },
                { new ConnectionEntity { From = "bll", To = "sptz" } },
                { new ConnectionEntity { From = "bll", To = "hlm" } },
                { new ConnectionEntity { From = "klp", To = "mrn" } },
                { new ConnectionEntity { From = "aml", To = "vz" } },
                { new ConnectionEntity { From = "da", To = "vz" } },
                { new ConnectionEntity { From = "da", To = "vhp" } },
                { new ConnectionEntity { From = "gdk", To = "vhp" } },
                { new ConnectionEntity { From = "gdk", To = "mrb" } },
                { new ConnectionEntity { From = "ktr", To = "tl" } },
                { new ConnectionEntity { From = "gdm", To = "tl" } },
                { new ConnectionEntity { From = "ktr", To = "op" } },
                { new ConnectionEntity { From = "hmn", To = "op" } },
                { new ConnectionEntity { From = "hmn", To = "za" } },
                { new ConnectionEntity { From = "est", To = "za" } },
                { new ConnectionEntity { From = "hgl", To = "hglo" } },
                { new ConnectionEntity { From = "hglo", To = "odz" } },
                { new ConnectionEntity { From = "go", To = "lc" } },
                { new ConnectionEntity { From = "go", To = "ddn" } },
                { new ConnectionEntity { From = "hgl", To = "ddn" } },
                { new ConnectionEntity { From = "lc", To = "zp" } },
                { new ConnectionEntity { From = "mes", To = "mt" } },
                { new ConnectionEntity { From = "mes", To = "sgl" } },
                { new ConnectionEntity { From = "sgl", To = "vk" } },
                { new ConnectionEntity { From = "vk", To = "sog" } },
                { new ConnectionEntity { From = "sog", To = "kmr" } },
                { new ConnectionEntity { From = "kmr", To = "vdl" } },
                { new ConnectionEntity { From = "vdl", To = "hrl" } },
                { new ConnectionEntity { From = "hrl", To = "lg" } },
                { new ConnectionEntity { From = "lg", To = "egh" } },
                { new ConnectionEntity { From = "egh", To = "cvm" } },
                { new ConnectionEntity { From = "cvm", To = "krd" } },
                { new ConnectionEntity { From = "tg", To = "vl" } },
                { new ConnectionEntity { From = "rv", To = "tg" } },
                { new ConnectionEntity { From = "mrb", To = "hdb" } },
                { new ConnectionEntity { From = "rv", To = "sm" } },
                { new ConnectionEntity { From = "rm", To = "sm" } },
                { new ConnectionEntity { From = "lw", To = "mg" } },
                { new ConnectionEntity { From = "mg", To = "sknd" } },
                { new ConnectionEntity { From = "sk", To = "sknd" } },
                { new ConnectionEntity { From = "ijt", To = "sk" } },
                { new ConnectionEntity { From = "ijt", To = "wk" } },
                { new ConnectionEntity { From = "hnp", To = "wk" } },
                { new ConnectionEntity { From = "hnp", To = "kmw" } },
                { new ConnectionEntity { From = "kmw", To = "stv" } },
                { new ConnectionEntity { From = "dei", To = "lw" } },
                { new ConnectionEntity { From = "dei", To = "drp" } },
                { new ConnectionEntity { From = "drp", To = "fn" } },
                { new ConnectionEntity { From = "fn", To = "hlg" } },
                { new ConnectionEntity { From = "hlg", To = "hlgh" } },
                { new ConnectionEntity { From = "bp", To = "zww" } },
                { new ConnectionEntity { From = "zww", To = "vwd" } },
                { new ConnectionEntity { From = "vwd", To = "hdg" } },
                { new ConnectionEntity { From = "lw", To = "hdg" } },
                { new ConnectionEntity { From = "gk", To = "zh" } },
                { new ConnectionEntity { From = "bp", To = "gk" } },
                { new ConnectionEntity { From = "gn", To = "zh" } },
                { new ConnectionEntity { From = "gn", To = "gnn" } },
                { new ConnectionEntity { From = "gn", To = "hrn" } },
                { new ConnectionEntity { From = "hrn", To = "kw" } },
                { new ConnectionEntity { From = "kw", To = "mth" } },
                { new ConnectionEntity { From = "mth", To = "hgz" } },
                { new ConnectionEntity { From = "hgz", To = "spm" } },
                { new ConnectionEntity { From = "spm", To = "zb" } },
                { new ConnectionEntity { From = "zb", To = "sda" } },
                { new ConnectionEntity { From = "sda", To = "ws" } },
                { new ConnectionEntity { From = "ws", To = "nsch" } },
                { new ConnectionEntity { From = "gnn", To = "swd" } },
                { new ConnectionEntity { From = "swd", To = "wsm" } },
                { new ConnectionEntity { From = "bf", To = "wsm" } },
                { new ConnectionEntity { From = "bf", To = "wfm" } },
                { new ConnectionEntity { From = "ust", To = "wfm" } },
                { new ConnectionEntity { From = "uhz", To = "ust" } },
                { new ConnectionEntity { From = "uhm", To = "uhz" } },
                { new ConnectionEntity { From = "rd", To = "uhm" } },
                { new ConnectionEntity { From = "bdm", To = "swd" } },
                { new ConnectionEntity { From = "bdm", To = "stm" } },
                { new ConnectionEntity { From = "lp", To = "stm" } },
                { new ConnectionEntity { From = "apg", To = "lp" } },
                { new ConnectionEntity { From = "apg", To = "dzw" } },
                { new ConnectionEntity { From = "dz", To = "dzw" } },
                { new ConnectionEntity { From = "ht", To = "zbm" } },
                { new ConnectionEntity { From = "asa", To = "asdm" } },
                { new ConnectionEntity { From = "asd", To = "asdm" } },
                { new ConnectionEntity { From = "cl", To = "htn" } },
                { new ConnectionEntity { From = "cl", To = "gdm" } },
                { new ConnectionEntity { From = "gdm", To = "zbm" } },
                { new ConnectionEntity { From = "brn", To = "hvs" } },
                { new ConnectionEntity { From = "amf", To = "brn" } },
                { new ConnectionEntity { From = "ot", To = "tb" } },
                { new ConnectionEntity { From = "btl", To = "ot" } },
                { new ConnectionEntity { From = "bsd", To = "ldm" } },
                { new ConnectionEntity { From = "bsd", To = "gdm" } },
                { new ConnectionEntity { From = "akl", To = "gr" } },
                { new ConnectionEntity { From = "gr", To = "gnd" } },
                { new ConnectionEntity { From = "gnd", To = "sdt" } },
                { new ConnectionEntity { From = "sdt", To = "ddrs" } },
                { new ConnectionEntity { From = "akl", To = "ldm" } },
                { new ConnectionEntity { From = "zdk", To = "zd" } },
                { new ConnectionEntity { From = "zdk", To = "pmr" } },
                { new ConnectionEntity { From = "pmo", To = "pmr" } },
                { new ConnectionEntity { From = "htn", To = "utl" } },
                { new ConnectionEntity { From = "ut", To = "utl" } },
                { new ConnectionEntity { From = "ddr", To = "ddrs" } },
                { new ConnectionEntity { From = "gdg", To = "wd" } },
                { new ConnectionEntity { From = "hor", To = "uto" } },
                { new ConnectionEntity { From = "hor", To = "hvsp" } },
            };
        }
        #endregion

        #region StopLocation functions
        public IEnumerable<StopLocationEntity> GetAllStopLocations()
        {
            return new List<StopLocationEntity>
           {
                { new StopLocationEntity { LocationId = "ac", Name = "Abcoude", Lattitude = 52.27337F, Longitude = 4.98162F } },
                { new StopLocationEntity { LocationId = "ah", Name = "Arnhem", Lattitude = 51.98497F, Longitude = 5.90196F } },
                { new StopLocationEntity { LocationId = "ahp", Name = "Arnhem Velperpoort", Lattitude = 51.98527F, Longitude = 5.92028F } },
                { new StopLocationEntity { LocationId = "ahpr", Name = "Arnhem Presikhaaf", Lattitude = 51.98781F, Longitude = 5.94277F } },
                { new StopLocationEntity { LocationId = "akl", Name = "Arkel", Lattitude = 51.87235F, Longitude = 4.99300F } },
                { new StopLocationEntity { LocationId = "akm", Name = "Akkrum", Lattitude = 53.04798F, Longitude = 5.84310F } },
                { new StopLocationEntity { LocationId = "alm", Name = "Almere", Lattitude = 52.37540F, Longitude = 5.21883F } },
                { new StopLocationEntity {LocationId = "almb", Name = "Almere Buiten", Lattitude = 52.39465F, Longitude = 5.27838F } },
                { new StopLocationEntity { LocationId = "almm", Name = "Almere Muziekwijk", Lattitude = 52.36788F, Longitude = 5.19047F } },
                { new StopLocationEntity { LocationId = "almp", Name = "Almere Parkwijk", Lattitude = 52.37707F, Longitude = 5.24449F } },
                { new StopLocationEntity { LocationId = "amf", Name = "Amersfoort", Lattitude = 52.15397F, Longitude = 5.37395F } },
                { new StopLocationEntity { LocationId = "amfs", Name = "Amersfoort Schothorst", Lattitude = 52.17563F, Longitude = 5.40495F } },
                { new StopLocationEntity { LocationId = "aml", Name = "Almelo", Lattitude = 52.35723F, Longitude = 6.65548F } },
                { new StopLocationEntity { LocationId = "amr", Name = "Alkmaar", Lattitude = 52.63830F, Longitude = 4.74073F } },
                { new StopLocationEntity { LocationId = "amri", Name = "Almelo-De Riet", Lattitude = 52.34255F, Longitude = 6.66619F } },
                { new StopLocationEntity { LocationId = "amrn", Name = "Alkmaar Noord", Lattitude = 52.64410F, Longitude = 4.76382F } },
                { new StopLocationEntity { LocationId = "ana", Name = "Anna-Paulowna", Lattitude = 52.86795F, Longitude = 4.81119F } },
                { new StopLocationEntity { LocationId = "apd", Name = "Apeldoorn", Lattitude = 52.20943F, Longitude = 5.97032F } },
                { new StopLocationEntity { LocationId = "apg", Name = "Appingedam", Lattitude = 53.32613F, Longitude = 6.86198F } },
                { new StopLocationEntity { LocationId = "apn", Name = "Alphen a/d Rijn", Lattitude = 52.12492F, Longitude = 4.65723F } },
                { new StopLocationEntity { LocationId = "arn", Name = "Arnemuiden", Lattitude = 51.50185F, Longitude = 3.66973F } },
                { new StopLocationEntity { LocationId = "asa", Name = "Amsterdam Amstel", Lattitude = 52.34610F, Longitude = 4.91796F } },
                { new StopLocationEntity { LocationId = "asb", Name = "Amsterdam Bijlmer", Lattitude = 52.31178F, Longitude = 4.94767F } },
                { new StopLocationEntity { LocationId = "asd", Name = "Amsterdam Centraal", Lattitude = 52.37910F, Longitude = 4.90032F } },
                { new StopLocationEntity { LocationId = "asdl", Name = "Amsterdam Lelylaan", Lattitude = 52.35811F, Longitude = 4.83390F } },
                { new StopLocationEntity { LocationId = "asdm", Name = "Amsterdam Muiderpoort", Lattitude = 52.36117F, Longitude = 4.93109F } },
                { new StopLocationEntity { LocationId = "asdv", Name = "Amsterdam Vlugtlaan", Lattitude = 52.37750F, Longitude = 4.83695F } },
                { new StopLocationEntity { LocationId = "asdz", Name = "Amsterdam-Zuid WTC", Lattitude = 52.33912F, Longitude = 4.87317F } },
                { new StopLocationEntity { LocationId = "asn", Name = "Assen", Lattitude = 52.99225F, Longitude = 6.57105F } },
                { new StopLocationEntity { LocationId = "ass", Name = "Amsterdam Sloterdijk", Lattitude = 52.38950F, Longitude = 4.83803F } },
                { new StopLocationEntity { LocationId = "atn", Name = "Aalten", Lattitude = 51.92153F, Longitude = 6.57870F } },
                { new StopLocationEntity { LocationId = "bd", Name = "Breda", Lattitude = 51.59551F, Longitude = 4.78002F } },
                { new StopLocationEntity { LocationId = "bde", Name = "Bunde", Lattitude = 50.89713F, Longitude = 5.73659F } },
                { new StopLocationEntity { LocationId = "bdg", Name = "Bodegraven", Lattitude = 52.08178F, Longitude = 4.74603F } },
                { new StopLocationEntity { LocationId = "bdm", Name = "Bedum", Lattitude = 53.30727F, Longitude = 6.59300F } },
                { new StopLocationEntity { LocationId = "bdpb", Name = "Breda-Prinsenbeek", Lattitude = 51.60617F, Longitude = 4.72128F } },
                { new StopLocationEntity { LocationId = "bet", Name = "Best", Lattitude = 51.50975F, Longitude = 5.38927F } },
                { new StopLocationEntity { LocationId = "bf", Name = "Baflo", Lattitude = 53.36108F, Longitude = 6.51887F } },
                { new StopLocationEntity { LocationId = "bgn", Name = "Bergen op Zoom", Lattitude = 51.49548F, Longitude = 4.29608F } },
                { new StopLocationEntity { LocationId = "bhv", Name = "Bilthoven", Lattitude = 52.13016F, Longitude = 5.20408F } },
                { new StopLocationEntity { LocationId = "bk", Name = "Beek-Elsloo", Lattitude = 50.94735F, Longitude = 5.78573F } },
                { new StopLocationEntity { LocationId = "bkf", Name = "Bovenkarspel-Flora", Lattitude = 52.69630F, Longitude = 5.25297F } },
                { new StopLocationEntity { LocationId = "bkg", Name = "Bovenkarspel-Grootebroek", Lattitude = 52.69532F, Longitude = 5.23600F } },
                { new StopLocationEntity { LocationId = "bkl", Name = "Breukelen", Lattitude = 52.17015F, Longitude = 4.99050F } },
                { new StopLocationEntity { LocationId = "bl", Name = "Beilen", Lattitude = 52.85518F, Longitude = 6.52123F } },
                { new StopLocationEntity { LocationId = "bll", Name = "Bloemendaal", Lattitude = 52.40470F, Longitude = 4.62770F } },
                { new StopLocationEntity { LocationId = "bmn", Name = "Brummen", Lattitude = 52.09105F, Longitude = 6.14688F } },
                { new StopLocationEntity { LocationId = "bmr", Name = "Boxmeer", Lattitude = 51.64445F, Longitude = 5.93935F } },
                { new StopLocationEntity { LocationId = "bn", Name = "Borne", Lattitude = 52.29856F, Longitude = 6.74875F } },
                { new StopLocationEntity { LocationId = "bnc", Name = "Barneveld-Centrum", Lattitude = 52.14083F, Longitude = 5.58983F } },
                { new StopLocationEntity { LocationId = "bnk", Name = "Bunnik", Lattitude = 52.06347F, Longitude = 5.19572F } },
                { new StopLocationEntity { LocationId = "bnn", Name = "Barneveld-Noord", Lattitude = 52.16107F, Longitude = 5.59875F } },
                { new StopLocationEntity { LocationId = "bp", Name = "Buitenpost", Lattitude = 53.25675F, Longitude = 6.14473F } },
                { new StopLocationEntity { LocationId = "br", Name = "Blerick", Lattitude = 51.37253F, Longitude = 6.15560F } },
                { new StopLocationEntity { LocationId = "brd", Name = "Barendrecht", Lattitude = 51.85510F, Longitude = 4.55269F } },
                { new StopLocationEntity { LocationId = "brn", Name = "Baarn", Lattitude = 52.20802F, Longitude = 5.28203F } },
                { new StopLocationEntity { LocationId = "bsd", Name = "Beesd", Lattitude = 51.89968F, Longitude = 5.19478F } },
                { new StopLocationEntity { LocationId = "bsk", Name = "Boskop", Lattitude = 52.07668F, Longitude = 4.64645F } },
                { new StopLocationEntity { LocationId = "bsmz", Name = "Bussum-Zuid", Lattitude = 52.26562F, Longitude = 5.16300F } },
                { new StopLocationEntity { LocationId = "btl", Name = "Boxtel", Lattitude = 51.58490F, Longitude = 5.31882F } },
                { new StopLocationEntity { LocationId = "bv", Name = "Beverwijk", Lattitude = 52.47822F, Longitude = 4.65559F } },
                { new StopLocationEntity { LocationId = "bzl", Name = "Kapelle-Biezelinge", Lattitude = 51.48070F, Longitude = 3.95675F } },
                { new StopLocationEntity { LocationId = "cas", Name = "Castricum", Lattitude = 52.54568F, Longitude = 4.65903F } },
                { new StopLocationEntity { LocationId = "ck", Name = "Cuijk", Lattitude = 51.72747F, Longitude = 5.87385F } },
                { new StopLocationEntity { LocationId = "cl", Name = "Culemborg", Lattitude = 51.94696F, Longitude = 5.22682F } },
                { new StopLocationEntity { LocationId = "co", Name = "Coevorden", Lattitude = 52.66329F, Longitude = 6.73578F } },
                { new StopLocationEntity { LocationId = "cps", Name = "Capelle-Schollevaar", Lattitude = 51.95443F, Longitude = 4.58398F } },
                { new StopLocationEntity { LocationId = "cvm", Name = "Chevremont", Lattitude = 50.87641F, Longitude = 6.05952F } },
                { new StopLocationEntity { LocationId = "da", Name = "Daarlerveen", Lattitude = 52.44102F, Longitude = 6.57610F } },
                { new StopLocationEntity { LocationId = "db", Name = "Driebergen-Zeist", Lattitude = 52.06555F, Longitude = 5.25994F } },
                { new StopLocationEntity { LocationId = "ddn", Name = "Delden", Lattitude = 52.26036F, Longitude = 6.71480F } },
                { new StopLocationEntity { LocationId = "ddr", Name = "Dordrecht", Lattitude = 51.80756F, Longitude = 4.66777F } },
                { new StopLocationEntity { LocationId = "ddrs", Name = "Dordrecht-Stadspolders", Lattitude = 51.80214F, Longitude = 4.71702F } },
                { new StopLocationEntity { LocationId = "ddzd", Name = "Dordrecht-Zuid", Lattitude = 51.79038F, Longitude = 4.67150F } },
                { new StopLocationEntity { LocationId = "dei", Name = "Deinum", Lattitude = 53.18905F, Longitude = 5.72820F } },
                { new StopLocationEntity { LocationId = "did", Name = "Didam", Lattitude = 51.93363F, Longitude = 6.13247F } },
                { new StopLocationEntity { LocationId = "dl", Name = "Dalfsen", Lattitude = 52.49850F, Longitude = 6.25950F } },
                { new StopLocationEntity { LocationId = "dld", Name = "Den Dolder", Lattitude = 52.14030F, Longitude = 5.24173F } },
                { new StopLocationEntity { LocationId = "dln", Name = "Dalen", Lattitude = 52.69468F, Longitude = 6.75835F } },
                { new StopLocationEntity { LocationId = "dmn", Name = "Diemen", Lattitude = 52.34580F, Longitude = 4.96728F } },
                { new StopLocationEntity { LocationId = "dmnz", Name = "Diemen-Zuid", Lattitude = 52.33070F, Longitude = 4.95622F } },
                { new StopLocationEntity { LocationId = "dmp", Name = "Zoetermeer-Driemanspolder", Lattitude = 52.04843F, Longitude = 4.47808F } },
                { new StopLocationEntity { LocationId = "dn", Name = "Deurne", Lattitude = 51.45632F, Longitude = 5.78808F } },
                { new StopLocationEntity { LocationId = "dr", Name = "Dieren", Lattitude = 52.04507F, Longitude = 6.10303F } },
                { new StopLocationEntity { LocationId = "drh", Name = "Driehuis", Lattitude = 52.44338F, Longitude = 4.63930F } },
                { new StopLocationEntity { LocationId = "drp", Name = "Dronrijp", Lattitude = 53.17802F, Longitude = 5.63468F } },
                { new StopLocationEntity { LocationId = "dt", Name = "Delft", Lattitude = 52.00685F, Longitude = 4.35618F } },
                { new StopLocationEntity { LocationId = "dtc", Name = "Doetinchem", Lattitude = 51.95862F, Longitude = 6.29622F } },
                { new StopLocationEntity { LocationId = "dtch", Name = "Doetinchem-De Huet", Lattitude = 51.95940F, Longitude = 6.25981F } },
                { new StopLocationEntity { LocationId = "dtwa", Name = "Zoetermeer - Delftse Wallen", Lattitude = 52.05132F, Longitude = 4.48737F } },
                { new StopLocationEntity { LocationId = "dtz", Name = "Delft-Zuid", Lattitude = 51.99123F, Longitude = 4.36479F } },
                { new StopLocationEntity { LocationId = "dv", Name = "Deventer", Lattitude = 52.25744F, Longitude = 6.16120F } },
                { new StopLocationEntity { LocationId = "dvc", Name = "Deventer-Comschate", Lattitude = 52.25062F, Longitude = 6.21550F } },
                { new StopLocationEntity { LocationId = "dvd", Name = "Duivendrecht", Lattitude = 52.32393F, Longitude = 4.93648F } },
                { new StopLocationEntity { LocationId = "dvn", Name = "Duiven", Lattitude = 51.94360F, Longitude = 6.01465F } },
                { new StopLocationEntity { LocationId = "dvnk", Name = "De Vink", Lattitude = 52.14687F, Longitude = 4.45578F } },
                { new StopLocationEntity { LocationId = "dz", Name = "Delfzijl", Lattitude = 53.33430F, Longitude = 6.92552F } },
                { new StopLocationEntity { LocationId = "dzw", Name = "Delfzijl-West", Lattitude = 53.33216F, Longitude = 6.90703F } },
                { new StopLocationEntity { LocationId = "ec", Name = "Echt", Lattitude = 51.10067F, Longitude = 5.87892F } },
                { new StopLocationEntity { LocationId = "ed", Name = "Ede-Wageningen", Lattitude = 52.02812F, Longitude = 5.67157F } },
                { new StopLocationEntity { LocationId = "edc", Name = "Ede-Centrum", Lattitude = 52.04377F, Longitude = 5.66820F } },
                { new StopLocationEntity { LocationId = "edn", Name = "Eijsden", Lattitude = 50.77215F, Longitude = 5.71005F } },
                { new StopLocationEntity { LocationId = "egh", Name = "Eygelshoven", Lattitude = 50.88996F, Longitude = 6.04579F } },
                { new StopLocationEntity { LocationId = "ehb", Name = "Eindhoven-Beukenlaan", Lattitude = 51.45042F, Longitude = 5.45728F } },
                { new StopLocationEntity { LocationId = "ehv", Name = "Eindhoven", Lattitude = 51.44322F, Longitude = 5.47953F } },
                { new StopLocationEntity { LocationId = "ekz", Name = "Enkhuizen", Lattitude = 52.69975F, Longitude = 5.28767F } },
                { new StopLocationEntity { LocationId = "eml", Name = "Ermelo", Lattitude = 52.30118F, Longitude = 5.61423F } },
                { new StopLocationEntity { LocationId = "emn", Name = "Emmen", Lattitude = 52.79087F, Longitude = 6.89975F } },
                { new StopLocationEntity { LocationId = "emnb", Name = "Emmen-Bargeres", Lattitude = 52.75821F, Longitude = 6.88997F } },
                { new StopLocationEntity { LocationId = "es", Name = "Enschede", Lattitude = 52.22282F, Longitude = 6.89018F } },
                { new StopLocationEntity { LocationId = "est", Name = "Elst", Lattitude = 51.91727F, Longitude = 5.85509F } },
                { new StopLocationEntity { LocationId = "etn", Name = "Etten-Leur", Lattitude = 51.57568F, Longitude = 4.63737F } },
                { new StopLocationEntity { LocationId = "fn", Name = "Franeker", Lattitude = 53.18262F, Longitude = 5.54833F } },
                { new StopLocationEntity { LocationId = "gbg", Name = "Gramsbergen", Lattitude = 52.61047F, Longitude = 6.67660F } },
                { new StopLocationEntity { LocationId = "gd", Name = "Gouda", Lattitude = 52.01757F, Longitude = 4.70660F } },
                { new StopLocationEntity { LocationId = "gdg", Name = "Gouda-Goverwelle", Lattitude = 52.01530F, Longitude = 4.74122F } },
                { new StopLocationEntity { LocationId = "gdk", Name = "Geerdijk", Lattitude = 52.47548F, Longitude = 6.56700F } },
                { new StopLocationEntity { LocationId = "gdm", Name = "Geldermalsen", Lattitude = 51.88277F, Longitude = 5.27148F } },
                { new StopLocationEntity { LocationId = "gk", Name = "Grijpskerk", Lattitude = 53.25608F, Longitude = 6.30977F } },
                { new StopLocationEntity { LocationId = "gln", Name = "Geleen-Oost", Lattitude = 50.96763F, Longitude = 5.84343F } },
                { new StopLocationEntity { LocationId = "gn", Name = "Groningen", Lattitude = 53.21098F, Longitude = 6.56375F } },
                { new StopLocationEntity { LocationId = "gnd", Name = "Hardinxveld-Giessendam", Lattitude = 51.83069F, Longitude = 4.83523F } },
                { new StopLocationEntity { LocationId = "gnn", Name = "Groningen-Noord", Lattitude = 53.23022F, Longitude = 6.55642F } },
                { new StopLocationEntity { LocationId = "go", Name = "Goor", Lattitude = 52.23048F, Longitude = 6.58601F } },
                { new StopLocationEntity { LocationId = "gp", Name = "Geldrop", Lattitude = 51.42025F, Longitude = 5.55045F } },
                { new StopLocationEntity { LocationId = "gr", Name = "Gorinchem", Lattitude = 51.83398F, Longitude = 4.96742F } },
                { new StopLocationEntity { LocationId = "gs", Name = "Goes", Lattitude = 51.49857F, Longitude = 3.89067F } },
                { new StopLocationEntity { LocationId = "gv", Name = "Den Haag Holland Spoor", Lattitude = 52.07020F, Longitude = 4.32299F } },
                { new StopLocationEntity { LocationId = "gvc", Name = "Den Haag Centraal", Lattitude = 52.08035F, Longitude = 4.32535F } },
                { new StopLocationEntity { LocationId = "gvm", Name = "Den Haag Mariahoeve", Lattitude = 52.09123F, Longitude = 4.36995F } },
                { new StopLocationEntity { LocationId = "gvmw", Name = "Den Haag Moerwijk", Lattitude = 52.05465F, Longitude = 4.30853F } },
                { new StopLocationEntity { LocationId = "gw", Name = "Grou-Jirnsum", Lattitude = 53.09033F, Longitude = 5.82217F } },
                { new StopLocationEntity { LocationId = "gz", Name = "Gilze-Rijen", Lattitude = 51.58420F, Longitude = 4.92422F } },
                { new StopLocationEntity { LocationId = "had", Name = "Heemstede-Aerdenhout", Lattitude = 52.35942F, Longitude = 4.60655F } },
                { new StopLocationEntity { LocationId = "hb", Name = "Hoensbroek", Lattitude = 50.90586F, Longitude = 5.93015F } },
                { new StopLocationEntity { LocationId = "hd", Name = "Harderwijk", Lattitude = 52.33777F, Longitude = 5.61994F } },
                { new StopLocationEntity { LocationId = "hdb", Name = "Hardenberg", Lattitude = 52.57245F, Longitude = 6.62787F } },
                { new StopLocationEntity { LocationId = "hde", Name = "´t Harde", Lattitude = 52.40911F, Longitude = 5.89237F } },
                { new StopLocationEntity { LocationId = "hdg", Name = "Hardegarijp", Lattitude = 53.21918F, Longitude = 5.93445F } },
                { new StopLocationEntity { LocationId = "hdr", Name = "Den Helder", Lattitude = 52.95638F, Longitude = 4.76090F } },
                { new StopLocationEntity { LocationId = "hdrz", Name = "Den Helder-Zuid", Lattitude = 52.93322F, Longitude = 4.76391F } },
                { new StopLocationEntity { LocationId = "hfd", Name = "Hoofddorp", Lattitude = 52.29370F, Longitude = 4.70102F } },
                { new StopLocationEntity { LocationId = "hgl", Name = "Hengelo", Lattitude = 52.26212F, Longitude = 6.79350F } },
                { new StopLocationEntity { LocationId = "hglo", Name = "Hengelo-Oost", Lattitude = 52.26948F, Longitude = 6.82050F } },
                { new StopLocationEntity { LocationId = "hgv", Name = "Hoogeveen", Lattitude = 52.73380F, Longitude = 6.47272F } },
                { new StopLocationEntity { LocationId = "hgz", Name = "Hoogezand-Sappemeer", Lattitude = 53.15995F, Longitude = 6.77010F } },
                { new StopLocationEntity { LocationId = "hil", Name = "Hillegom", Lattitude = 52.30475F, Longitude = 4.56783F } },
                { new StopLocationEntity { LocationId = "hk", Name = "Heemskerk", Lattitude = 52.49483F, Longitude = 4.68588F } },
                { new StopLocationEntity { LocationId = "hks", Name = "Hoogkarspel", Lattitude = 52.69055F, Longitude = 5.18238F } },
                { new StopLocationEntity { LocationId = "hld", Name = "Hoek Van Holland", Lattitude = 51.97672F, Longitude = 4.12732F } },
                { new StopLocationEntity { LocationId = "hlds", Name = "Hoek van Holland Strand", Lattitude = 51.98212F, Longitude = 4.11930F } },
                { new StopLocationEntity { LocationId = "hlg", Name = "Harlingen", Lattitude = 53.17043F, Longitude = 5.42516F } },
                { new StopLocationEntity { LocationId = "hlgh", Name = "Harlingen Haven", Lattitude = 53.17477F, Longitude = 5.40988F } },
                { new StopLocationEntity { LocationId = "hlm", Name = "Haarlem", Lattitude = 52.38827F, Longitude = 4.63847F } },
                { new StopLocationEntity { LocationId = "hlo", Name = "Heiloo", Lattitude = 52.60035F, Longitude = 4.70102F } },
                { new StopLocationEntity { LocationId = "hm", Name = "Helmond", Lattitude = 51.47565F, Longitude = 5.66186F } },
                { new StopLocationEntity { LocationId = "hmbh", Name = "Helmond-Brouwhuis", Lattitude = 51.47097F, Longitude = 5.70176F } },
                { new StopLocationEntity { LocationId = "hmh", Name = "NS Helmond - 't Hout", Lattitude = 51.46815F, Longitude = 5.63082F } },
                { new StopLocationEntity { LocationId = "hmn", Name = "Hemmen-Dodewaard", Lattitude = 51.92258F, Longitude = 5.67363F } },
                { new StopLocationEntity { LocationId = "hn", Name = "Hoorn", Lattitude = 52.64537F, Longitude = 5.05460F } },
                { new StopLocationEntity { LocationId = "hnk", Name = "Hoorn-Kersenboogaard", Lattitude = 52.65343F, Longitude = 5.08467F } },
                { new StopLocationEntity { LocationId = "hno", Name = "Heinoo", Lattitude = 52.42758F, Longitude = 6.22137F } },
                { new StopLocationEntity { LocationId = "hnp", Name = "Hindeloopen", Lattitude = 52.94671F, Longitude = 5.42322F } },
                { new StopLocationEntity { LocationId = "hon", Name = "Holten", Lattitude = 52.28436F, Longitude = 6.42140F } },
                { new StopLocationEntity { LocationId = "hor", Name = "Hollandsche Rading", Lattitude = 52.17837F, Longitude = 5.17920F } },
                { new StopLocationEntity { LocationId = "hr", Name = "Heerenveen", Lattitude = 52.96090F, Longitude = 5.91545F } },
                { new StopLocationEntity { LocationId = "hrl", Name = "Heerlen", Lattitude = 50.89097F, Longitude = 5.97555F } },
                { new StopLocationEntity { LocationId = "hrn", Name = "Haren", Lattitude = 53.17517F, Longitude = 6.61838F } },
                { new StopLocationEntity { LocationId = "hrt", Name = "Horst-Sevenum", Lattitude = 51.42703F, Longitude = 6.04162F } },
                { new StopLocationEntity { LocationId = "hry", Name = "Heerenveen IJsstadion", Lattitude = 52.93552F, Longitude = 5.94390F } },
                { new StopLocationEntity { LocationId = "ht", Name = "´s-Hertogenbosch", Lattitude = 51.69097F, Longitude = 5.29363F } },
                { new StopLocationEntity { LocationId = "htn", Name = "Houten", Lattitude = 52.03463F, Longitude = 5.16788F } },
                { new StopLocationEntity { LocationId = "hto", Name = "´s-Hertogenbosch-Oost", Lattitude = 51.70082F, Longitude = 5.31847F } },
                { new StopLocationEntity { LocationId = "hvs", Name = "Hilversum", Lattitude = 52.22605F, Longitude = 5.18208F } },
                { new StopLocationEntity { LocationId = "hvsn", Name = "Hilversum-Noord", Lattitude = 52.23883F, Longitude = 5.17362F } },
                { new StopLocationEntity { LocationId = "hvsp", Name = "Hilversum-Sportpark", Lattitude = 52.21683F, Longitude = 5.18728F } },
                { new StopLocationEntity { LocationId = "hwd", Name = "Heerhugowaard", Lattitude = 52.67080F, Longitude = 4.82417F } },
                { new StopLocationEntity { LocationId = "hze", Name = "Heeze", Lattitude = 51.38545F, Longitude = 5.56959F } },
                { new StopLocationEntity { LocationId = "ijt", Name = "IJlst", Lattitude = 53.01307F, Longitude = 5.61273F } },
                { new StopLocationEntity { LocationId = "kbd", Name = "Krabendijke", Lattitude = 51.43347F, Longitude = 4.11735F } },
                { new StopLocationEntity { LocationId = "kbk", Name = "Klarenbeek", Lattitude = 52.17817F, Longitude = 6.08465F } },
                { new StopLocationEntity { LocationId = "kbw", Name = "Koog-Bloemwijk", Lattitude = 52.45850F, Longitude = 4.80568F } },
                { new StopLocationEntity { LocationId = "klp", Name = "Veenendaal-De Klomp", Lattitude = 52.04617F, Longitude = 5.57335F } },
                { new StopLocationEntity { LocationId = "kma", Name = "Krommenie-Assendelft", Lattitude = 52.49459F, Longitude = 4.76125F } },
                { new StopLocationEntity { LocationId = "kmr", Name = "Klimmen-Ransdaal", Lattitude = 50.86668F, Longitude = 5.89058F } },
                { new StopLocationEntity { LocationId = "kmw", Name = "Koudum-Molkwerum", Lattitude = 52.90305F, Longitude = 5.41078F } },
                { new StopLocationEntity { LocationId = "krd", Name = "Kerkrade", Lattitude = 50.86133F, Longitude = 6.05725F } },
                { new StopLocationEntity { LocationId = "krg", Name = "Kruiningen-Yerseke", Lattitude = 51.46577F, Longitude = 4.03652F } },
                { new StopLocationEntity { LocationId = "ktr", Name = "Kesteren", Lattitude = 51.93185F, Longitude = 5.58387F } },
                { new StopLocationEntity { LocationId = "kw", Name = "Kropswolde", Lattitude = 53.16197F, Longitude = 6.72217F } },
                { new StopLocationEntity { LocationId = "kzd", Name = "Koog aan de Zaan", Lattitude = 52.46863F, Longitude = 4.80515F } },
                { new StopLocationEntity { LocationId = "laa", Name = "Den Haag Laan van Nieuw-Oost-Indië", Lattitude = 52.07938F, Longitude = 4.34355F } },
                { new StopLocationEntity { LocationId = "lc", Name = "lochem", Lattitude = 52.16703F, Longitude = 6.42669F } },
                { new StopLocationEntity { LocationId = "ldl", Name = "Leiden-Lammenschans", Lattitude = 52.14700F, Longitude = 4.49265F } },
                { new StopLocationEntity { LocationId = "ldm", Name = "Leerdam", Lattitude = 51.89490F, Longitude = 5.09310F } },
                { new StopLocationEntity { LocationId = "ldv", Name = "Leidschemdam-Voorburg", Lattitude = 52.07730F, Longitude = 4.38322F } },
                { new StopLocationEntity { LocationId = "ledn", Name = "Leiden", Lattitude = 52.16693F, Longitude = 4.48252F } },
                { new StopLocationEntity { LocationId = "ley", Name = "Zoetermeer - De Leyens", Lattitude = 52.07223F, Longitude = 4.49470F } },
                { new StopLocationEntity { LocationId = "lg", Name = "Landgraaf", Lattitude = 50.89675F, Longitude = 6.01967F } },
                { new StopLocationEntity { LocationId = "lls", Name = "Lelystad", Lattitude = 52.50820F, Longitude = 5.47277F } },
                { new StopLocationEntity { LocationId = "lp", Name = "Loppersum", Lattitude = 53.33505F, Longitude = 6.74743F } },
                { new StopLocationEntity { LocationId = "ltn", Name = "Lunteren", Lattitude = 52.08547F, Longitude = 5.62417F } },
                { new StopLocationEntity { LocationId = "ltv", Name = "Lichtenvoorde-Groenlo", Lattitude = 52.01279F, Longitude = 6.59455F } },
                { new StopLocationEntity { LocationId = "lut", Name = "Geleen-Lutterade", Lattitude = 50.97565F, Longitude = 5.82488F } },
                { new StopLocationEntity { LocationId = "lw", Name = "Leeuwarden", Lattitude = 53.19662F, Longitude = 5.79305F } },
                { new StopLocationEntity { LocationId = "mas", Name = "Maarssen", Lattitude = 52.13590F, Longitude = 5.03360F } },
                { new StopLocationEntity { LocationId = "mdb", Name = "Middelburg", Lattitude = 51.49535F, Longitude = 3.61817F } },
                { new StopLocationEntity { LocationId = "mes", Name = "Meerssen", Lattitude = 50.88277F, Longitude = 5.75088F } },
                { new StopLocationEntity { LocationId = "mg", Name = "Mantgum", Lattitude = 53.12995F, Longitude = 5.71320F } },
                { new StopLocationEntity { LocationId = "mp", Name = "Meppel", Lattitude = 52.69215F, Longitude = 6.19788F } },
                { new StopLocationEntity { LocationId = "mrb", Name = "Mariënberg", Lattitude = 52.50912F, Longitude = 6.57438F } },
                { new StopLocationEntity { LocationId = "mrn", Name = "Maarn", Lattitude = 52.06443F, Longitude = 5.37032F } },
                { new StopLocationEntity { LocationId = "mss", Name = "Maassluis", Lattitude = 51.91682F, Longitude = 4.25350F } },
                { new StopLocationEntity { LocationId = "msw", Name = "Maassluis-West", Lattitude = 51.92597F, Longitude = 4.22112F } },
                { new StopLocationEntity { LocationId = "mt", Name = "Maastricht", Lattitude = 50.84998F, Longitude = 5.70598F } },
                { new StopLocationEntity { LocationId = "mth", Name = "Martenshoek", Lattitude = 53.16100F, Longitude = 6.74028F } },
                { new StopLocationEntity { LocationId = "mtr", Name = "Maastricht-Randwyck", Lattitude = 50.83794F, Longitude = 5.71765F } },
                { new StopLocationEntity { LocationId = "na", Name = "Nieuw Amsterdam", Lattitude = 52.71873F, Longitude = 6.84877F } },
                { new StopLocationEntity { LocationId = "ndb", Name = "Naarden-Bussum", Lattitude = 52.28117F, Longitude = 5.15700F } },
                { new StopLocationEntity { LocationId = "nh", Name = "Nuth", Lattitude = 50.92043F, Longitude = 5.89267F } },
                { new StopLocationEntity { LocationId = "nkk", Name = "Nijkerk", Lattitude = 52.22255F, Longitude = 5.49382F } },
                { new StopLocationEntity { LocationId = "nm", Name = "Nijmegen", Lattitude = 51.84340F, Longitude = 5.85230F } },
                { new StopLocationEntity { LocationId = "nmd", Name = "Nijmegen-Dukenburg", Lattitude = 51.82430F, Longitude = 5.79508F } },
                { new StopLocationEntity { LocationId = "nmh", Name = "Nijmegen-Heyendaal", Lattitude = 51.82718F, Longitude = 5.86778F } },
                { new StopLocationEntity { LocationId = "ns", Name = "Nunspeet", Lattitude = 52.37123F, Longitude = 5.78468F } },
                { new StopLocationEntity { LocationId = "nsch", Name = "Nieuweschans", Lattitude = 53.18463F, Longitude = 7.19944F } },
                { new StopLocationEntity { LocationId = "nvd", Name = "Nijverdal", Lattitude = 52.36594F, Longitude = 6.47013F } },
                { new StopLocationEntity { LocationId = "nvp", Name = "Nieuw-Vennep", Lattitude = 52.25940F, Longitude = 4.64571F } },
                { new StopLocationEntity { LocationId = "nwk", Name = "Nieuwerkerk a/d IJssel", Lattitude = 51.96555F, Longitude = 4.61677F } },
                { new StopLocationEntity { LocationId = "nwl", Name = "Schiedam-Nieuwland", Lattitude = 51.92317F, Longitude = 4.38360F } },
                { new StopLocationEntity { LocationId = "o", Name = "Oss", Lattitude = 51.76500F, Longitude = 5.52967F } },
                { new StopLocationEntity { LocationId = "obd", Name = "Obdam", Lattitude = 52.67817F, Longitude = 4.90912F } },
                { new StopLocationEntity { LocationId = "odb", Name = "Oudenbosch", Lattitude = 51.58797F, Longitude = 4.53310F } },
                { new StopLocationEntity { LocationId = "odz", Name = "Oldenzaal", Lattitude = 52.30662F, Longitude = 6.93507F } },
                { new StopLocationEntity { LocationId = "omn", Name = "Ommen", Lattitude = 52.51000F, Longitude = 6.41782F } },
                { new StopLocationEntity { LocationId = "op", Name = "Opheusden", Lattitude = 51.92633F, Longitude = 5.63709F } },
                { new StopLocationEntity { LocationId = "ost", Name = "Olst", Lattitude = 52.33593F, Longitude = 6.11345F } },
                { new StopLocationEntity { LocationId = "ot", Name = "Oisterwijk", Lattitude = 51.58229F, Longitude = 5.19345F } },
                { new StopLocationEntity { LocationId = "otb", Name = "Oosterbeek", Lattitude = 51.99468F, Longitude = 5.84142F } },
                { new StopLocationEntity { LocationId = "ovn", Name = "Overveen", Lattitude = 52.39108F, Longitude = 4.60755F } },
                { new StopLocationEntity { LocationId = "ow", Name = "Oss-West", Lattitude = 51.75861F, Longitude = 5.50668F } },
                { new StopLocationEntity { LocationId = "pmo", Name = "Purmerend Overwhere", Lattitude = 52.51167F, Longitude = 4.96770F } },
                { new StopLocationEntity { LocationId = "pmr", Name = "Purmerend", Lattitude = 52.50409F, Longitude = 4.95420F } },
                { new StopLocationEntity { LocationId = "pnk", Name = "Pijnacker", Lattitude = 52.01868F, Longitude = 4.43843F } },
                { new StopLocationEntity { LocationId = "pt", Name = "Putten", Lattitude = 52.26578F, Longitude = 5.57587F } },
                { new StopLocationEntity { LocationId = "rai", Name = "Amsterdam-RAI", Lattitude = 52.33755F, Longitude = 4.88950F } },
                { new StopLocationEntity { LocationId = "rat", Name = "Raalte", Lattitude = 52.39142F, Longitude = 6.27853F } },
                { new StopLocationEntity { LocationId = "rb", Name = "Rilland-Bath", Lattitude = 51.42293F, Longitude = 4.16368F } },
                { new StopLocationEntity { LocationId = "rd", Name = "Roodeschool", Lattitude = 53.41955F, Longitude = 6.76075F } },
                { new StopLocationEntity { LocationId = "rdr", Name = "Berkel en Rodenrijs", Lattitude = 51.97610F, Longitude = 4.46058F } },
                { new StopLocationEntity { LocationId = "rh", Name = "Rheden", Lattitude = 52.01040F, Longitude = 6.03137F } },
                { new StopLocationEntity { LocationId = "rhn", Name = "Rhenen", Lattitude = 51.95842F, Longitude = 5.57830F } },
                { new StopLocationEntity { LocationId = "rl", Name = "Ruurlo", Lattitude = 52.08125F, Longitude = 6.44923F } },
                { new StopLocationEntity { LocationId = "rlb", Name = "Roterdam Lombardijen", Lattitude = 51.88040F, Longitude = 4.53096F } },
                { new StopLocationEntity { LocationId = "rm", Name = "Roermond", Lattitude = 51.19330F, Longitude = 5.99470F } },
                { new StopLocationEntity { LocationId = "rs", Name = "Rosmalen", Lattitude = 51.71525F, Longitude = 5.36922F } },
                { new StopLocationEntity { LocationId = "rsd", Name = "Roosendaal", Lattitude = 51.54034F, Longitude = 4.45834F } },
                { new StopLocationEntity { LocationId = "rsn", Name = "Rijssen", Lattitude = 52.31210F, Longitude = 6.51922F } },
                { new StopLocationEntity { LocationId = "rsw", Name = "Rijswijk", Lattitude = 52.03983F, Longitude = 4.31952F } },
                { new StopLocationEntity { LocationId = "rta", Name = "Rotterdam-Alexander", Lattitude = 51.95188F, Longitude = 4.55192F } },
                { new StopLocationEntity { LocationId = "rtb", Name = "Rotterdam Blaak", Lattitude = 51.92000F, Longitude = 4.48965F } },
                { new StopLocationEntity { LocationId = "rtbw", Name = "Rotterdam Bergweg", Lattitude = 51.93245F, Longitude = 4.46671F } },
                { new StopLocationEntity { LocationId = "rtd", Name = "Rotterdam Centraal", Lattitude = 51.92549F, Longitude = 4.46953F } },
                { new StopLocationEntity { LocationId = "rth", Name = "Rotterdam Hofplein", Lattitude = 51.92700F, Longitude = 4.47922F } },
                { new StopLocationEntity { LocationId = "rtkw", Name = "Rotterdam Kleiweg", Lattitude = 51.94613F, Longitude = 4.46603F } },
                { new StopLocationEntity { LocationId = "rtn", Name = "Roterdam Noord", Lattitude = 51.94250F, Longitude = 4.48105F } },
                { new StopLocationEntity { LocationId = "rtwp", Name = "Rotterdam Wilgenplas", Lattitude = 51.96138F, Longitude = 4.46228F } },
                { new StopLocationEntity { LocationId = "rtz", Name = "Rotterdam Zuid", Lattitude = 51.90310F, Longitude = 4.51172F } },
                { new StopLocationEntity { LocationId = "rv", Name = "Reuver", Lattitude = 51.28330F, Longitude = 6.07948F } },
                { new StopLocationEntity { LocationId = "rvs", Name = "Ravenstein", Lattitude = 51.79507F, Longitude = 5.63738F } },
                { new StopLocationEntity { LocationId = "sbk", Name = "Spaubeek", Lattitude = 50.94361F, Longitude = 5.84972F } },
                { new StopLocationEntity { LocationId = "sd", Name = "Soestdijk", Lattitude = 52.18318F, Longitude = 5.30017F } },
                { new StopLocationEntity { LocationId = "sda", Name = "Scheemda", Lattitude = 53.16562F, Longitude = 6.97785F } },
                { new StopLocationEntity { LocationId = "sdm", Name = "Schiedam Centrum", Lattitude = 51.92219F, Longitude = 4.40957F } },
                { new StopLocationEntity { LocationId = "sdn", Name = "Soestduinen", Lattitude = 52.14532F, Longitude = 5.29845F } },
                { new StopLocationEntity { LocationId = "sdt", Name = "Sliedrecht", Lattitude = 51.82993F, Longitude = 4.77785F } },
                { new StopLocationEntity { LocationId = "sgl", Name = "Houthem-St. Gerlach", Lattitude = 50.87362F, Longitude = 5.79648F } },
                { new StopLocationEntity { LocationId = "sgn", Name = "Schagen", Lattitude = 52.78552F, Longitude = 4.80522F } },
                { new StopLocationEntity { LocationId = "shl", Name = "Schiphol", Lattitude = 52.30970F, Longitude = 4.76242F } },
                { new StopLocationEntity { LocationId = "sk", Name = "Sneek", Lattitude = 53.03297F, Longitude = 5.65240F } },
                { new StopLocationEntity { LocationId = "sknd", Name = "Sneek Noord", Lattitude = 53.04088F, Longitude = 5.66297F } },
                { new StopLocationEntity { LocationId = "sm", Name = "Swalmen", Lattitude = 51.23523F, Longitude = 6.03182F } },
                { new StopLocationEntity { LocationId = "sn", Name = "Schinnen", Lattitude = 50.93898F, Longitude = 5.87597F } },
                { new StopLocationEntity { LocationId = "sog", Name = "Schin op Geul", Lattitude = 50.85632F, Longitude = 5.87200F } },
                { new StopLocationEntity { LocationId = "spm", Name = "Sappemeer Oost", Lattitude = 53.15913F, Longitude = 6.79574F } },
                { new StopLocationEntity { LocationId = "sptn", Name = "Santpoort Noord", Lattitude = 52.43362F, Longitude = 4.63238F } },
                { new StopLocationEntity { LocationId = "sptz", Name = "Santpoort Zuid", Lattitude = 52.41968F, Longitude = 4.63142F } },
                { new StopLocationEntity { LocationId = "srn", Name = "Susteren", Lattitude = 51.06086F, Longitude = 5.86300F } },
                { new StopLocationEntity { LocationId = "st", Name = "Soest", Lattitude = 52.17358F, Longitude = 5.31010F } },
                { new StopLocationEntity { LocationId = "std", Name = "Sittard", Lattitude = 51.00213F, Longitude = 5.85870F } },
                { new StopLocationEntity { LocationId = "stm", Name = "Stedum", Lattitude = 53.32662F, Longitude = 6.68751F } },
                { new StopLocationEntity { LocationId = "stv", Name = "Stavoren", Lattitude = 52.88695F, Longitude = 5.36000F } },
                { new StopLocationEntity { LocationId = "stz", Name = "Soest Zuid", Lattitude = 52.16568F, Longitude = 5.30315F } },
                { new StopLocationEntity { LocationId = "swd", Name = "Sauwerd", Lattitude = 53.29188F, Longitude = 6.54046F } },
                { new StopLocationEntity { LocationId = "swk", Name = "Steenwijk", Lattitude = 52.79083F, Longitude = 6.11877F } },
                { new StopLocationEntity { LocationId = "tb", Name = "Tilburg", Lattitude = 51.56080F, Longitude = 5.08398F } },
                { new StopLocationEntity { LocationId = "tbg", Name = "Terborg", Lattitude = 51.92284F, Longitude = 6.36442F } },
                { new StopLocationEntity { LocationId = "tbwt", Name = "Tilburg West", Lattitude = 51.56520F, Longitude = 5.05160F } },
                { new StopLocationEntity { LocationId = "tg", Name = "Tegelen", Lattitude = 51.33508F, Longitude = 6.13675F } },
                { new StopLocationEntity { LocationId = "tl", Name = "Tiel", Lattitude = 51.88982F, Longitude = 5.42262F } },
                { new StopLocationEntity { LocationId = "uhm", Name = "Uithuizermeeden", Lattitude = 53.41416F, Longitude = 6.72038F } },
                { new StopLocationEntity { LocationId = "uhz", Name = "Uithuizen", Lattitude = 53.40993F, Longitude = 6.67495F } },
                { new StopLocationEntity { LocationId = "ust", Name = "Usquert", Lattitude = 53.40123F, Longitude = 6.60952F } },
                { new StopLocationEntity { LocationId = "ut", Name = "Utrecht Centraal", Lattitude = 52.08999F, Longitude = 5.10955F } },
                { new StopLocationEntity { LocationId = "utg", Name = "Uitgeest", Lattitude = 52.52128F, Longitude = 4.70347F } },
                { new StopLocationEntity { LocationId = "utl", Name = "Utrecht Lunetten", Lattitude = 52.06625F, Longitude = 5.14363F } },
                { new StopLocationEntity { LocationId = "utm", Name = "Utrecht Maliebaan (Museum)", Lattitude = 52.08838F, Longitude = 5.13168F } },
                { new StopLocationEntity { LocationId = "uto", Name = "Utrecht Overvecht", Lattitude = 52.10985F, Longitude = 5.12355F } },
                { new StopLocationEntity { LocationId = "vb", Name = "Voorburg", Lattitude = 52.06674F, Longitude = 4.35970F } },
                { new StopLocationEntity { LocationId = "vbl", Name = "NS Voorburg - 't Loo", Lattitude = 52.08264F, Longitude = 4.36518F } },
                { new StopLocationEntity { LocationId = "vd", Name = "Vorden", Lattitude = 52.10762F, Longitude = 6.31713F } },
                { new StopLocationEntity { LocationId = "vdg", Name = "Vlaardingen", Lattitude = 51.90361F, Longitude = 4.34455F } },
                { new StopLocationEntity { LocationId = "vdl", Name = "Voerendaal", Lattitude = 50.88701F, Longitude = 5.92952F } },
                { new StopLocationEntity { LocationId = "vdo", Name = "Vlaardingen Oost", Lattitude = 51.91043F, Longitude = 4.36160F } },
                { new StopLocationEntity { LocationId = "vdw", Name = "Vlaardingen West", Lattitude = 51.90422F, Longitude = 4.31477F } },
                { new StopLocationEntity { LocationId = "vg", Name = "Vught", Lattitude = 51.65593F, Longitude = 5.29189F } },
                { new StopLocationEntity { LocationId = "vh", Name = "Voorhout", Lattitude = 52.22256F, Longitude = 4.48503F } },
                { new StopLocationEntity { LocationId = "vhp", Name = "Vroomshoop", Lattitude = 52.45737F, Longitude = 6.56967F } },
                { new StopLocationEntity { LocationId = "vk", Name = "Valkenburg", Lattitude = 50.86952F, Longitude = 5.83302F } },
                { new StopLocationEntity { LocationId = "vl", Name = "Venlo", Lattitude = 51.36483F, Longitude = 6.17107F } },
                { new StopLocationEntity { LocationId = "vlb", Name = "Vierlingsbeek", Lattitude = 51.59212F, Longitude = 5.99720F } },
                { new StopLocationEntity { LocationId = "vndc", Name = "Veenendaal Centrum", Lattitude = 52.02023F, Longitude = 5.54881F } },
                { new StopLocationEntity { LocationId = "vndw", Name = "Veenendaal West", Lattitude = 52.02913F, Longitude = 5.52912F } },
                { new StopLocationEntity { LocationId = "vry", Name = "Venray", Lattitude = 51.52679F, Longitude = 6.01440F } },
                { new StopLocationEntity { LocationId = "vs", Name = "Vlissingen", Lattitude = 51.44583F, Longitude = 3.59528F } },
                { new StopLocationEntity { LocationId = "vss", Name = "Vlissingen-Souburg", Lattitude = 51.46501F, Longitude = 3.59513F } },
                { new StopLocationEntity { LocationId = "vst", Name = "Voorschoten", Lattitude = 52.12783F, Longitude = 4.43527F } },
                { new StopLocationEntity { LocationId = "vsv", Name = "Varsseveld", Lattitude = 51.93745F, Longitude = 6.45865F } },
                { new StopLocationEntity { LocationId = "vtn", Name = "Vleuten", Lattitude = 52.10305F, Longitude = 5.01205F } },
                { new StopLocationEntity { LocationId = "vwd", Name = "Veenwouden", Lattitude = 53.23503F, Longitude = 5.98863F } },
                { new StopLocationEntity { LocationId = "vz", Name = "Vriezeveen", Lattitude = 52.40119F, Longitude = 6.60117F } },
                { new StopLocationEntity { LocationId = "wad", Name = "Waddinxveen", Lattitude = 52.04495F, Longitude = 4.64985F } },
                { new StopLocationEntity { LocationId = "wadn", Name = "Waddinxveen Noord", Lattitude = 52.05568F, Longitude = 4.64840F } },
                { new StopLocationEntity { LocationId = "wc", Name = "Wijchen", Lattitude = 51.81167F, Longitude = 5.73008F } },
                { new StopLocationEntity { LocationId = "wd", Name = "Woerden", Lattitude = 52.08541F, Longitude = 4.89367F } },
                { new StopLocationEntity { LocationId = "wdn", Name = "Wierden", Lattitude = 52.36174F, Longitude = 6.59233F } },
                { new StopLocationEntity { LocationId = "wf", Name = "Wolfheze", Lattitude = 52.00579F, Longitude = 5.79257F } },
                { new StopLocationEntity { LocationId = "wfm", Name = "Warffum", Lattitude = 53.39060F, Longitude = 6.56737F } },
                { new StopLocationEntity { LocationId = "wh", Name = "Wijhe", Lattitude = 52.39130F, Longitude = 6.14108F } },
                { new StopLocationEntity { LocationId = "wk", Name = "Workum", Lattitude = 52.97228F, Longitude = 5.45654F } },
                { new StopLocationEntity { LocationId = "wl", Name = "Wehl", Lattitude = 51.95753F, Longitude = 6.21395F } },
                { new StopLocationEntity { LocationId = "wm", Name = "Wormerveer", Lattitude = 52.48937F, Longitude = 4.79306F } },
                { new StopLocationEntity { LocationId = "wp", Name = "Weesp", Lattitude = 52.31238F, Longitude = 5.04420F } },
                { new StopLocationEntity { LocationId = "ws", Name = "Winschoten", Lattitude = 53.13942F, Longitude = 7.03509F } },
                { new StopLocationEntity { LocationId = "wsm", Name = "Winsum", Lattitude = 53.33002F, Longitude = 6.52048F } },
                { new StopLocationEntity { LocationId = "wt", Name = "Weert", Lattitude = 51.24897F, Longitude = 5.70536F } },
                { new StopLocationEntity { LocationId = "wv", Name = "Wolvega", Lattitude = 52.88025F, Longitude = 6.00493F } },
                { new StopLocationEntity { LocationId = "ww", Name = "Winterwijk", Lattitude = 51.96789F, Longitude = 6.71550F } },
                { new StopLocationEntity { LocationId = "wz", Name = "Wezep", Lattitude = 52.45385F, Longitude = 6.00172F } },
                { new StopLocationEntity { LocationId = "za", Name = "Zetten-Andelst", Lattitude = 51.91990F, Longitude = 5.72290F } },
                { new StopLocationEntity { LocationId = "zb", Name = "Zuidbroek", Lattitude = 53.15955F, Longitude = 6.86800F } },
                { new StopLocationEntity { LocationId = "zbm", Name = "Zaltbommel", Lattitude = 51.80824F, Longitude = 5.26335F } },
                { new StopLocationEntity { LocationId = "zd", Name = "Zaandam", Lattitude = 52.43863F, Longitude = 4.81372F } },
                { new StopLocationEntity { LocationId = "zdk", Name = "Zaandam-Kogerveld", Lattitude = 52.45700F, Longitude = 4.81972F } },
                { new StopLocationEntity { LocationId = "zh", Name = "Zuidhorn", Lattitude = 53.24858F, Longitude = 6.40633F } },
                { new StopLocationEntity { LocationId = "zl", Name = "Zwolle", Lattitude = 52.50578F, Longitude = 6.08971F } },
                { new StopLocationEntity { LocationId = "zlw", Name = "Lage Zwaluwe", Lattitude = 51.69067F, Longitude = 4.66342F } },
                { new StopLocationEntity { LocationId = "zp", Name = "Zutphen", Lattitude = 52.14510F, Longitude = 6.19467F } },
                { new StopLocationEntity { LocationId = "zsh", Name = "Zoetermeer Stadhuis", Lattitude = 52.06130F, Longitude = 4.49312F } },
                { new StopLocationEntity { LocationId = "ztm", Name = "Zoetermeer", Lattitude = 52.04777F, Longitude = 4.47805F } },
                { new StopLocationEntity { LocationId = "ztmb", Name = "Zoetermeer Buytenwegh", Lattitude = 52.06692F, Longitude = 4.47850F } },
                { new StopLocationEntity { LocationId = "ztmcw", Name = "Zoetermeer Centrum West", Lattitude = 52.06085F, Longitude = 4.48345F } },
                { new StopLocationEntity { LocationId = "ztmd", Name = "Zoetermeer Dorp", Lattitude = 52.05470F, Longitude = 4.49212F } },
                { new StopLocationEntity { LocationId = "ztml", Name = "Zoetermeer Leidse Wallen", Lattitude = 52.06918F, Longitude = 4.51063F } },
                { new StopLocationEntity { LocationId = "ztmm", Name = "Zoetermeer Meerzicht", Lattitude = 52.05603F, Longitude = 4.47004F } },
                { new StopLocationEntity { LocationId = "ztmo", Name = "Zoetermeer Oost", Lattitude = 52.04677F, Longitude = 4.49246F } },
                { new StopLocationEntity { LocationId = "ztmp", Name = "Zoetermeer Palenstein", Lattitude = 52.05993F, Longitude = 4.50645F } },
                { new StopLocationEntity { LocationId = "ztms", Name = "Zoetermeer Segwaert", Lattitude = 52.06323F, Longitude = 4.51518F } },
                { new StopLocationEntity { LocationId = "ztmv", Name = "Zoetermeer Voorweg", Lattitude = 52.06285F, Longitude = 4.47153F } },
                { new StopLocationEntity { LocationId = "zv", Name = "Zevenaar", Lattitude = 51.92297F, Longitude = 6.07354F } },
                { new StopLocationEntity { LocationId = "zvb", Name = "Zevenbergen", Lattitude = 51.64193F, Longitude = 4.61033F } },
                { new StopLocationEntity { LocationId = "zvt", Name = "Zantvoort aan Zee", Lattitude = 52.37573F, Longitude = 4.53202F } },
                { new StopLocationEntity { LocationId = "zwd", Name = "Zwijndrecht", Lattitude = 51.81562F, Longitude = 4.64067F } },
                { new StopLocationEntity { LocationId = "zww", Name = "Zwaagwesteinde", Lattitude = 53.24853F, Longitude = 6.03537F } },
            };
        }
        #endregion

        #region Route functions
        public IEnumerable<RouteEntity> GetRoutes(string departureTime)
        {
            return AllRoutes.Where(r => r.Departures[0].PlannedDepartureTime == departureTime);
        }

        public RouteEntity GetRoute(string id)
        {
            return AllRoutes.FirstOrDefault(r => r.RouteId == id);
        }

        public IEnumerable<RouteEntity> GetRoutes(string departureTimeFrom, string departureTimeTo)
        {
            return AllRoutes.Where(r =>
                        string.CompareOrdinal(r.Departures[0].PlannedDepartureTime, departureTimeFrom) >= 0 &&
                        string.CompareOrdinal(r.Departures[0].PlannedDepartureTime, departureTimeTo) <= 0);
        }

        public async Task<string> SaveRoute(RouteEntity route)
        {
            var routeToSave = AllRoutes.FirstOrDefault(r => r.RouteId == route.RouteId);
            if (routeToSave == null)
                throw new ApplicationException("Route can not be saved");

            routeToSave.Finished = route.Finished;
            routeToSave.Started = route.Started;
            routeToSave._id = route._id;
            routeToSave._rev = route._rev;
            route.Departures = route.Departures;

            return route._rev;
        }

        public int GetActiveRouteCount()
        {
            return AllRoutes.Count(r => r.Started && !r.Finished);
        }

        public List<VehicleStatusEntity> GetStatus(string vehicleId)
        {
            throw new NotImplementedException();
        }

        public Task SaveStatus(VehicleStatusEntity vehicleStatusEntity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAllStatusDocuments()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region private shizzle
        private IEnumerable<RouteEntity> AllRoutes
        {
            get
            {
                if (_routeEntities == null)
                {
                    lock (_syncRoot)
                    {
                        if (_routeEntities == null)
                        {
                            _routeEntities = GetAllRoutes();
                        }
                    }
                }

                return _routeEntities;
            }
        }

        private List<RouteEntity> GetAllRoutes()
        {
            return new List<RouteEntity>
            {
                new RouteEntity
                {
                   RouteId = "1", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "17:50", "17:50"),
                       new DepartureEntity("rta", "17:58", "17:58"),
                       new DepartureEntity("gd", "18:08", "18:09"),
                       new DepartureEntity("ut", "18:28", "18:36"),
                       new DepartureEntity("amf", "18:50", "18:53"),
                       new DepartureEntity("apd", "19:17", "19:18"),
                       new DepartureEntity("dv", "19:28", "19:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "2", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "17:50", "17:50"),
                       new DepartureEntity("rta", "17:58", "17:58"),
                       new DepartureEntity("gd", "18:08", "18:09"),
                       new DepartureEntity("ut", "18:28", "18:36"),
                       new DepartureEntity("amf", "18:50", "18:53"),
                       new DepartureEntity("apd", "19:17", "19:18"),
                       new DepartureEntity("dv", "19:28", "19:30"),
                       new DepartureEntity("aml", "19:55", "19:56"),
                       new DepartureEntity("hgl", "20:07", "20:08"),
                       new DepartureEntity("es", "20:15", "20:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "3", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "17:50", "17:50"),
                       new DepartureEntity("rta", "17:58", "17:58"),
                       new DepartureEntity("gd", "18:08", "18:13"),
                       new DepartureEntity("ut", "18:31", "18:36"),
                       new DepartureEntity("amf", "18:50", "18:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "4", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "17:50", "17:50"),
                       new DepartureEntity("rta", "17:58", "17:58"),
                       new DepartureEntity("gd", "18:08", "18:13"),
                       new DepartureEntity("ut", "18:31", "18:36"),
                       new DepartureEntity("amf", "18:50", "18:53"),
                       new DepartureEntity("apd", "19:17", "19:18"),
                       new DepartureEntity("dv", "19:28", "19:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "5", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "17:50", "17:50"),
                       new DepartureEntity("rta", "17:58", "17:58"),
                       new DepartureEntity("gd", "18:08", "18:13"),
                       new DepartureEntity("ut", "18:31", "18:36"),
                       new DepartureEntity("amf", "18:50", "18:53"),
                       new DepartureEntity("apd", "19:17", "19:18"),
                       new DepartureEntity("dv", "19:28", "19:30"),
                       new DepartureEntity("aml", "19:55", "19:56"),
                       new DepartureEntity("hgl", "20:07", "20:08"),
                       new DepartureEntity("es", "20:15", "20:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "6", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "18:36", "18:36"),
                       new DepartureEntity("amf", "18:50", "18:53"),
                       new DepartureEntity("apd", "19:17", "19:18"),
                       new DepartureEntity("dv", "19:28", "19:30"),
                       new DepartureEntity("aml", "19:55", "19:56"),
                       new DepartureEntity("hgl", "20:07", "20:08"),
                       new DepartureEntity("es", "20:15", "20:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "7", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "17:50", "17:50"),
                       new DepartureEntity("gd", "18:07", "18:13"),
                       new DepartureEntity("ut", "18:31", "18:36"),
                       new DepartureEntity("amf", "18:50", "18:53"),
                       new DepartureEntity("apd", "19:17", "19:18"),
                       new DepartureEntity("dv", "19:28", "19:30"),
                       new DepartureEntity("aml", "19:55", "19:56"),
                       new DepartureEntity("hgl", "20:07", "20:08"),
                       new DepartureEntity("es", "20:15", "20:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "8", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "17:53", "17:53"),
                       new DepartureEntity("gd", "18:10", "18:13"),
                       new DepartureEntity("ut", "18:31", "18:36"),
                       new DepartureEntity("amf", "18:50", "18:53"),
                       new DepartureEntity("apd", "19:17", "19:18"),
                       new DepartureEntity("dv", "19:28", "19:30"),
                       new DepartureEntity("aml", "19:55", "19:56"),
                       new DepartureEntity("hgl", "20:07", "20:08"),
                       new DepartureEntity("es", "20:15", "20:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "9", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "17:54", "17:54"),
                       new DepartureEntity("gd", "18:11", "18:12"),
                       new DepartureEntity("ut", "18:31", "18:36"),
                       new DepartureEntity("amf", "18:50", "18:53"),
                       new DepartureEntity("apd", "19:17", "19:18"),
                       new DepartureEntity("dv", "19:28", "19:30"),
                       new DepartureEntity("aml", "19:55", "19:56"),
                       new DepartureEntity("hgl", "20:07", "20:08"),
                       new DepartureEntity("es", "20:15", "20:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "10", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "17:53", "17:53"),
                       new DepartureEntity("gd", "18:10", "18:13"),
                       new DepartureEntity("ut", "18:31", "18:36"),
                       new DepartureEntity("amf", "18:50", "18:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "11", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "17:53", "17:53"),
                       new DepartureEntity("gd", "18:10", "18:13"),
                       new DepartureEntity("ut", "18:31", "18:36"),
                       new DepartureEntity("amf", "18:50", "18:53"),
                       new DepartureEntity("apd", "19:17", "19:18"),
                       new DepartureEntity("dv", "19:28", "19:30"),
                       new DepartureEntity("aml", "19:55", "19:56"),
                       new DepartureEntity("hgl", "20:07", "20:08"),
                       new DepartureEntity("es", "20:15", "20:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "12", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "17:54", "17:54"),
                       new DepartureEntity("gd", "18:11", "18:12"),
                       new DepartureEntity("ut", "18:31", "18:36"),
                       new DepartureEntity("amf", "18:50", "18:53"),
                       new DepartureEntity("apd", "19:17", "19:18"),
                       new DepartureEntity("dv", "19:28", "19:30"),
                       new DepartureEntity("aml", "19:55", "19:56"),
                       new DepartureEntity("hgl", "20:07", "20:08"),
                       new DepartureEntity("es", "20:15", "20:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "13", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "12:50", "12:50"),
                       new DepartureEntity("rta", "12:58", "12:58"),
                       new DepartureEntity("gd", "13:08", "13:09"),
                       new DepartureEntity("ut", "13:28", "13:36"),
                       new DepartureEntity("amf", "13:50", "13:53"),
                       new DepartureEntity("apd", "14:17", "14:18"),
                       new DepartureEntity("dv", "14:28", "14:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "14", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "12:50", "12:50"),
                       new DepartureEntity("rta", "12:58", "12:58"),
                       new DepartureEntity("gd", "13:08", "13:09"),
                       new DepartureEntity("ut", "13:28", "13:36"),
                       new DepartureEntity("amf", "13:50", "13:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "15", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "12:50", "12:50"),
                       new DepartureEntity("rta", "12:58", "12:58"),
                       new DepartureEntity("gd", "13:08", "13:13"),
                       new DepartureEntity("ut", "13:31", "13:36"),
                       new DepartureEntity("amf", "13:50", "13:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "16", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "12:50", "12:50"),
                       new DepartureEntity("rta", "12:58", "12:58"),
                       new DepartureEntity("gd", "13:08", "13:14"),
                       new DepartureEntity("ut", "13:32", "13:37"),
                       new DepartureEntity("amf", "13:50", "13:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "17", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "12:50", "12:50"),
                       new DepartureEntity("rta", "12:58", "12:58"),
                       new DepartureEntity("gd", "13:08", "13:13"),
                       new DepartureEntity("ut", "13:31", "13:36"),
                       new DepartureEntity("amf", "13:50", "13:53"),
                       new DepartureEntity("apd", "14:17", "14:18"),
                       new DepartureEntity("dv", "14:28", "14:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "18", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "13:36", "13:36"),
                       new DepartureEntity("amf", "13:50", "13:53"),
                       new DepartureEntity("apd", "14:17", "14:18"),
                       new DepartureEntity("dv", "14:28", "14:30"),
                       new DepartureEntity("aml", "14:55", "14:56"),
                       new DepartureEntity("hgl", "15:07", "15:08"),
                       new DepartureEntity("es", "15:15", "15:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "19", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "12:53", "12:53"),
                       new DepartureEntity("gd", "13:10", "13:13"),
                       new DepartureEntity("ut", "13:31", "13:36"),
                       new DepartureEntity("amf", "13:50", "13:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "20", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "12:50", "12:50"),
                       new DepartureEntity("gd", "13:07", "13:13"),
                       new DepartureEntity("ut", "13:31", "13:36"),
                       new DepartureEntity("amf", "13:50", "13:53"),
                       new DepartureEntity("apd", "14:17", "14:18"),
                       new DepartureEntity("dv", "14:28", "14:30"),
                       new DepartureEntity("aml", "14:55", "14:56"),
                       new DepartureEntity("hgl", "15:07", "15:08"),
                       new DepartureEntity("es", "15:15", "15:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "21", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "12:53", "12:53"),
                       new DepartureEntity("gd", "13:10", "13:13"),
                       new DepartureEntity("ut", "13:31", "13:36"),
                       new DepartureEntity("amf", "13:50", "13:53"),
                       new DepartureEntity("apd", "14:17", "14:18"),
                       new DepartureEntity("dv", "14:28", "14:30"),
                       new DepartureEntity("aml", "14:55", "14:56"),
                       new DepartureEntity("hgl", "15:07", "15:08"),
                       new DepartureEntity("es", "15:15", "15:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "22", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "12:54", "12:54"),
                       new DepartureEntity("gd", "13:11", "13:12"),
                       new DepartureEntity("ut", "13:31", "13:36"),
                       new DepartureEntity("amf", "13:50", "13:53"),
                       new DepartureEntity("apd", "14:17", "14:18"),
                       new DepartureEntity("dv", "14:28", "14:30"),
                       new DepartureEntity("aml", "14:55", "14:56"),
                       new DepartureEntity("hgl", "15:07", "15:08"),
                       new DepartureEntity("es", "15:15", "15:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "23", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "12:53", "12:53"),
                       new DepartureEntity("gd", "13:13", "13:14"),
                       new DepartureEntity("ut", "13:32", "13:37"),
                       new DepartureEntity("amf", "13:50", "13:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "24", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "12:54", "12:54"),
                       new DepartureEntity("gd", "13:11", "13:12"),
                       new DepartureEntity("ut", "13:31", "13:36"),
                       new DepartureEntity("amf", "13:50", "13:53"),
                       new DepartureEntity("apd", "14:17", "14:18"),
                       new DepartureEntity("dv", "14:28", "14:30"),
                       new DepartureEntity("aml", "14:55", "14:56"),
                       new DepartureEntity("hgl", "15:07", "15:08"),
                       new DepartureEntity("es", "15:15", "15:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "25", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "15:32", "15:32"),
                       new DepartureEntity("apd", "15:42", "15:43"),
                       new DepartureEntity("amf", "16:07", "16:10"),
                       new DepartureEntity("ut", "16:24", "16:32"),
                       new DepartureEntity("gd", "16:51", "16:52"),
                       new DepartureEntity("rta", "17:01", "17:01"),
                       new DepartureEntity("rtd", "17:10", "17:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "26", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "16:10", "16:10"),
                       new DepartureEntity("ut", "16:24", "16:29"),
                       new DepartureEntity("gd", "16:47", "16:52"),
                       new DepartureEntity("rta", "17:01", "17:01"),
                       new DepartureEntity("rtd", "17:10", "17:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "27", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "16:10", "16:10"),
                       new DepartureEntity("ut", "16:24", "16:29"),
                       new DepartureEntity("gd", "16:47", "16:52"),
                       new DepartureEntity("rta", "17:01", "17:01"),
                       new DepartureEntity("rtd", "17:10", "17:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "28", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "15:32", "15:32"),
                       new DepartureEntity("apd", "15:42", "15:43"),
                       new DepartureEntity("amf", "16:07", "16:10"),
                       new DepartureEntity("ut", "16:24", "16:29"),
                       new DepartureEntity("gd", "16:47", "16:52"),
                       new DepartureEntity("rta", "17:01", "17:01"),
                       new DepartureEntity("rtd", "17:10", "17:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "29", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "15:32", "15:32"),
                       new DepartureEntity("apd", "15:42", "15:43"),
                       new DepartureEntity("amf", "16:07", "16:10"),
                       new DepartureEntity("ut", "16:24", "16:29"),
                       new DepartureEntity("gd", "16:47", "16:52"),
                       new DepartureEntity("rta", "17:01", "17:01"),
                       new DepartureEntity("rtd", "17:10", "17:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "30", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "15:32", "15:32"),
                       new DepartureEntity("apd", "15:42", "15:43"),
                       new DepartureEntity("amf", "16:07", "16:10"),
                       new DepartureEntity("ut", "16:24", "16:32"),
                       new DepartureEntity("gd", "16:51", "16:52"),
                       new DepartureEntity("rta", "17:01", "17:01"),
                       new DepartureEntity("rtd", "17:10", "17:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "31", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "16:10", "16:10"),
                       new DepartureEntity("ut", "16:24", "16:32"),
                       new DepartureEntity("gd", "16:51", "16:52"),
                       new DepartureEntity("rta", "17:01", "17:01"),
                       new DepartureEntity("rtd", "17:10", "17:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "32", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "16:10", "16:10"),
                       new DepartureEntity("ut", "16:24", "16:29"),
                       new DepartureEntity("gd", "16:47", "16:49"),
                       new DepartureEntity("gvc", "17:07", "17:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "33", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "14:46", "14:46"),
                       new DepartureEntity("hgl", "14:53", "14:54"),
                       new DepartureEntity("aml", "15:05", "15:06"),
                       new DepartureEntity("dv", "15:29", "15:32"),
                       new DepartureEntity("apd", "15:42", "15:43"),
                       new DepartureEntity("amf", "16:07", "16:10"),
                       new DepartureEntity("ut", "16:24", "16:29"),
                       new DepartureEntity("gd", "16:47", "16:49"),
                       new DepartureEntity("gvc", "17:07", "17:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "34", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "14:46", "14:46"),
                       new DepartureEntity("hgl", "14:53", "14:54"),
                       new DepartureEntity("aml", "15:05", "15:06"),
                       new DepartureEntity("dv", "15:30", "15:32"),
                       new DepartureEntity("apd", "15:42", "15:43"),
                       new DepartureEntity("amf", "16:07", "16:10"),
                       new DepartureEntity("ut", "16:24", "16:29"),
                       new DepartureEntity("gd", "16:48", "16:49"),
                       new DepartureEntity("gvc", "17:07", "17:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "35", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "14:46", "14:46"),
                       new DepartureEntity("hgl", "14:53", "14:54"),
                       new DepartureEntity("aml", "15:05", "15:06"),
                       new DepartureEntity("dv", "15:29", "15:32"),
                       new DepartureEntity("apd", "15:42", "15:43"),
                       new DepartureEntity("amf", "16:07", "16:10"),
                       new DepartureEntity("ut", "16:24", "16:29"),
                       new DepartureEntity("gd", "16:48", "16:49"),
                       new DepartureEntity("gvc", "17:07", "17:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "36", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "14:46", "14:46"),
                       new DepartureEntity("hgl", "14:53", "14:54"),
                       new DepartureEntity("aml", "15:05", "15:06"),
                       new DepartureEntity("dv", "15:29", "15:32"),
                       new DepartureEntity("apd", "15:42", "15:43"),
                       new DepartureEntity("amf", "16:07", "16:10"),
                       new DepartureEntity("ut", "16:24", "16:29"),
                       new DepartureEntity("gd", "16:48", "16:49"),
                       new DepartureEntity("gvc", "17:07", "17:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "37", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "16:10", "16:10"),
                       new DepartureEntity("ut", "16:24", "16:29"),
                       new DepartureEntity("gd", "16:47", "16:49"),
                       new DepartureEntity("gvc", "17:07", "17:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "38", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "14:46", "14:46"),
                       new DepartureEntity("hgl", "14:53", "14:54"),
                       new DepartureEntity("aml", "15:05", "15:06"),
                       new DepartureEntity("dv", "15:29", "15:32"),
                       new DepartureEntity("apd", "15:42", "15:43"),
                       new DepartureEntity("amf", "16:07", "16:10"),
                       new DepartureEntity("ut", "16:26", "16:26"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "39", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "14:46", "14:46"),
                       new DepartureEntity("hgl", "14:53", "14:54"),
                       new DepartureEntity("aml", "15:05", "15:06"),
                       new DepartureEntity("dv", "15:29", "15:32"),
                       new DepartureEntity("apd", "15:42", "15:43"),
                       new DepartureEntity("amf", "16:07", "16:10"),
                       new DepartureEntity("ut", "16:24", "16:29"),
                       new DepartureEntity("gd", "16:48", "16:49"),
                       new DepartureEntity("gvc", "17:07", "17:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "40", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "14:46", "14:46"),
                       new DepartureEntity("hgl", "14:53", "14:54"),
                       new DepartureEntity("aml", "15:05", "15:06"),
                       new DepartureEntity("dv", "15:29", "15:32"),
                       new DepartureEntity("apd", "15:42", "15:43"),
                       new DepartureEntity("amf", "16:07", "16:10"),
                       new DepartureEntity("ut", "16:24", "16:29"),
                       new DepartureEntity("gd", "16:48", "16:49"),
                       new DepartureEntity("gvc", "17:07", "17:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "41", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "14:46", "14:46"),
                       new DepartureEntity("hgl", "14:53", "14:54"),
                       new DepartureEntity("aml", "15:05", "15:06"),
                       new DepartureEntity("dv", "15:29", "15:32"),
                       new DepartureEntity("apd", "15:42", "15:43"),
                       new DepartureEntity("amf", "16:07", "16:10"),
                       new DepartureEntity("ut", "16:24", "16:29"),
                       new DepartureEntity("gd", "16:49", "16:50"),
                       new DepartureEntity("gvc", "17:11", "17:11"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "42", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "08:10", "08:10"),
                       new DepartureEntity("ut", "08:24", "08:29"),
                       new DepartureEntity("gd", "08:47", "08:52"),
                       new DepartureEntity("rta", "09:01", "09:01"),
                       new DepartureEntity("rtd", "09:10", "09:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "43", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "06:46", "06:46"),
                       new DepartureEntity("hgl", "06:53", "06:54"),
                       new DepartureEntity("aml", "07:05", "07:06"),
                       new DepartureEntity("dv", "07:29", "07:32"),
                       new DepartureEntity("apd", "07:42", "07:43"),
                       new DepartureEntity("amf", "08:07", "08:10"),
                       new DepartureEntity("ut", "08:24", "08:29"),
                       new DepartureEntity("gd", "08:47", "08:52"),
                       new DepartureEntity("rta", "09:01", "09:01"),
                       new DepartureEntity("rtd", "09:10", "09:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "44", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "06:46", "06:46"),
                       new DepartureEntity("hgl", "06:53", "06:54"),
                       new DepartureEntity("aml", "07:05", "07:06"),
                       new DepartureEntity("dv", "07:29", "07:32"),
                       new DepartureEntity("apd", "07:42", "07:43"),
                       new DepartureEntity("amf", "08:07", "08:10"),
                       new DepartureEntity("ut", "08:24", "08:29"),
                       new DepartureEntity("gd", "08:47", "08:52"),
                       new DepartureEntity("rta", "09:01", "09:01"),
                       new DepartureEntity("rtd", "09:10", "09:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "45", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "06:46", "06:46"),
                       new DepartureEntity("hgl", "06:53", "06:54"),
                       new DepartureEntity("aml", "07:05", "07:06"),
                       new DepartureEntity("dv", "07:29", "07:32"),
                       new DepartureEntity("apd", "07:42", "07:43"),
                       new DepartureEntity("amf", "08:07", "08:10"),
                       new DepartureEntity("ut", "08:24", "08:32"),
                       new DepartureEntity("gd", "08:51", "08:52"),
                       new DepartureEntity("rta", "09:01", "09:01"),
                       new DepartureEntity("rtd", "09:10", "09:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "46", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "08:10", "08:10"),
                       new DepartureEntity("ut", "08:24", "08:29"),
                       new DepartureEntity("gd", "08:47", "08:49"),
                       new DepartureEntity("gvc", "09:07", "09:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "47", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "06:46", "06:46"),
                       new DepartureEntity("hgl", "06:53", "06:54"),
                       new DepartureEntity("aml", "07:05", "07:06"),
                       new DepartureEntity("dv", "07:29", "07:32"),
                       new DepartureEntity("apd", "07:42", "07:43"),
                       new DepartureEntity("amf", "08:07", "08:10"),
                       new DepartureEntity("ut", "08:26", "08:26"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "48", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "06:46", "06:46"),
                       new DepartureEntity("hgl", "06:53", "06:54"),
                       new DepartureEntity("aml", "07:05", "07:06"),
                       new DepartureEntity("dv", "07:29", "07:32"),
                       new DepartureEntity("apd", "07:42", "07:43"),
                       new DepartureEntity("amf", "08:07", "08:10"),
                       new DepartureEntity("ut", "08:24", "08:29"),
                       new DepartureEntity("gd", "08:48", "08:49"),
                       new DepartureEntity("gvc", "09:07", "09:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "49", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "06:46", "06:46"),
                       new DepartureEntity("hgl", "06:53", "06:54"),
                       new DepartureEntity("aml", "07:05", "07:06"),
                       new DepartureEntity("dv", "07:29", "07:32"),
                       new DepartureEntity("apd", "07:42", "07:43"),
                       new DepartureEntity("amf", "08:07", "08:10"),
                       new DepartureEntity("ut", "08:24", "08:29"),
                       new DepartureEntity("gd", "08:47", "08:49"),
                       new DepartureEntity("gvc", "09:07", "09:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "50", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "07:32", "07:32"),
                       new DepartureEntity("apd", "07:42", "07:43"),
                       new DepartureEntity("amf", "08:07", "08:10"),
                       new DepartureEntity("ut", "08:26", "08:26"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "51", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "07:32", "07:32"),
                       new DepartureEntity("apd", "07:42", "07:43"),
                       new DepartureEntity("amf", "08:07", "08:10"),
                       new DepartureEntity("ut", "08:24", "08:29"),
                       new DepartureEntity("gd", "08:49", "08:50"),
                       new DepartureEntity("gvc", "09:11", "09:11"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "52", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "08:10", "08:10"),
                       new DepartureEntity("ut", "08:24", "08:29"),
                       new DepartureEntity("gd", "08:47", "08:49"),
                       new DepartureEntity("gvc", "09:10", "09:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "53", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "07:32", "07:32"),
                       new DepartureEntity("apd", "07:42", "07:43"),
                       new DepartureEntity("amf", "08:07", "08:10"),
                       new DepartureEntity("ut", "08:24", "08:29"),
                       new DepartureEntity("gd", "08:47", "08:49"),
                       new DepartureEntity("gvc", "09:07", "09:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "54", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "06:46", "06:46"),
                       new DepartureEntity("hgl", "06:53", "06:54"),
                       new DepartureEntity("aml", "07:05", "07:06"),
                       new DepartureEntity("dv", "07:29", "07:32"),
                       new DepartureEntity("apd", "07:42", "07:43"),
                       new DepartureEntity("amf", "08:07", "08:10"),
                       new DepartureEntity("ut", "08:24", "08:29"),
                       new DepartureEntity("gd", "08:48", "08:49"),
                       new DepartureEntity("gvc", "09:07", "09:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "55", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "06:46", "06:46"),
                       new DepartureEntity("hgl", "06:53", "06:54"),
                       new DepartureEntity("aml", "07:05", "07:06"),
                       new DepartureEntity("dv", "07:29", "07:32"),
                       new DepartureEntity("apd", "07:42", "07:43"),
                       new DepartureEntity("amf", "08:07", "08:10"),
                       new DepartureEntity("ut", "08:24", "08:29"),
                       new DepartureEntity("gd", "08:49", "08:50"),
                       new DepartureEntity("gvc", "09:11", "09:11"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "56", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "09:20", "09:20"),
                       new DepartureEntity("rta", "09:28", "09:28"),
                       new DepartureEntity("gd", "09:38", "09:39"),
                       new DepartureEntity("ut", "09:58", "10:06"),
                       new DepartureEntity("amf", "10:20", "10:25"),
                       new DepartureEntity("amfs", "10:29", "10:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "57", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "09:20", "09:20"),
                       new DepartureEntity("rta", "09:28", "09:28"),
                       new DepartureEntity("gd", "09:38", "09:43"),
                       new DepartureEntity("ut", "10:01", "10:06"),
                       new DepartureEntity("amf", "10:20", "10:25"),
                       new DepartureEntity("amfs", "10:29", "10:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "58", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "10:06", "10:06"),
                       new DepartureEntity("amf", "10:20", "10:20"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "59", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "09:23", "09:23"),
                       new DepartureEntity("gd", "09:40", "09:43"),
                       new DepartureEntity("ut", "10:01", "10:06"),
                       new DepartureEntity("amf", "10:20", "10:25"),
                       new DepartureEntity("amfs", "10:29", "10:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "60", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "09:20", "09:20"),
                       new DepartureEntity("gd", "09:37", "09:43"),
                       new DepartureEntity("ut", "10:01", "10:06"),
                       new DepartureEntity("amf", "10:20", "10:25"),
                       new DepartureEntity("amfs", "10:29", "10:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "61", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "09:23", "09:23"),
                       new DepartureEntity("gd", "09:40", "09:43"),
                       new DepartureEntity("ut", "10:01", "10:06"),
                       new DepartureEntity("amf", "10:20", "10:25"),
                       new DepartureEntity("amfs", "10:29", "10:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "62", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "09:24", "09:24"),
                       new DepartureEntity("gd", "09:41", "09:42"),
                       new DepartureEntity("ut", "10:01", "10:06"),
                       new DepartureEntity("amf", "10:20", "10:25"),
                       new DepartureEntity("amfs", "10:29", "10:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "63", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "09:23", "09:23"),
                       new DepartureEntity("gd", "09:40", "09:43"),
                       new DepartureEntity("ut", "10:01", "10:06"),
                       new DepartureEntity("amf", "10:20", "10:25"),
                       new DepartureEntity("amfs", "10:29", "10:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "64", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "09:23", "09:23"),
                       new DepartureEntity("gd", "09:43", "09:44"),
                       new DepartureEntity("ut", "10:02", "10:07"),
                       new DepartureEntity("amf", "10:20", "10:25"),
                       new DepartureEntity("amfs", "10:29", "10:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "65", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "09:20", "09:20"),
                       new DepartureEntity("gd", "09:37", "09:43"),
                       new DepartureEntity("ut", "10:01", "10:06"),
                       new DepartureEntity("amf", "10:20", "10:25"),
                       new DepartureEntity("amfs", "10:29", "10:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "66", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "10:06", "10:06"),
                       new DepartureEntity("amf", "10:20", "10:20"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "67", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "10:34", "10:34"),
                       new DepartureEntity("amf", "10:38", "10:40"),
                       new DepartureEntity("ut", "10:54", "10:59"),
                       new DepartureEntity("gd", "11:17", "11:22"),
                       new DepartureEntity("rta", "11:31", "11:31"),
                       new DepartureEntity("rtd", "11:40", "11:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "68", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "10:34", "10:34"),
                       new DepartureEntity("amf", "10:38", "10:40"),
                       new DepartureEntity("ut", "10:54", "10:59"),
                       new DepartureEntity("gd", "11:17", "11:22"),
                       new DepartureEntity("rta", "11:31", "11:31"),
                       new DepartureEntity("rtd", "11:40", "11:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "69", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "10:34", "10:34"),
                       new DepartureEntity("amf", "10:38", "10:40"),
                       new DepartureEntity("ut", "10:54", "11:02"),
                       new DepartureEntity("gd", "11:21", "11:22"),
                       new DepartureEntity("rta", "11:31", "11:31"),
                       new DepartureEntity("rtd", "11:40", "11:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "70", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "10:40", "10:40"),
                       new DepartureEntity("ut", "10:56", "10:56"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "71", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "10:34", "10:34"),
                       new DepartureEntity("amf", "10:38", "10:40"),
                       new DepartureEntity("ut", "10:54", "10:59"),
                       new DepartureEntity("gd", "11:17", "11:19"),
                       new DepartureEntity("gvc", "11:37", "11:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "72", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "10:34", "10:34"),
                       new DepartureEntity("amf", "10:38", "10:40"),
                       new DepartureEntity("ut", "10:54", "10:59"),
                       new DepartureEntity("gd", "11:19", "11:20"),
                       new DepartureEntity("gvc", "11:41", "11:41"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "73", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "10:34", "10:34"),
                       new DepartureEntity("amf", "10:38", "10:40"),
                       new DepartureEntity("ut", "10:54", "10:59"),
                       new DepartureEntity("gd", "11:17", "11:19"),
                       new DepartureEntity("gvc", "11:37", "11:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "74", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "10:40", "10:40"),
                       new DepartureEntity("ut", "10:56", "10:56"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "75", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "10:34", "10:34"),
                       new DepartureEntity("amf", "10:38", "10:40"),
                       new DepartureEntity("ut", "10:54", "10:59"),
                       new DepartureEntity("gd", "11:18", "11:19"),
                       new DepartureEntity("gvc", "11:37", "11:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "76", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "10:34", "10:34"),
                       new DepartureEntity("amf", "10:38", "10:40"),
                       new DepartureEntity("ut", "10:54", "10:59"),
                       new DepartureEntity("gd", "11:17", "11:19"),
                       new DepartureEntity("gvc", "11:37", "11:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "77", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "10:34", "10:34"),
                       new DepartureEntity("amf", "10:38", "10:40"),
                       new DepartureEntity("ut", "10:54", "10:59"),
                       new DepartureEntity("gd", "11:18", "11:19"),
                       new DepartureEntity("gvc", "11:37", "11:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "78", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "10:34", "10:34"),
                       new DepartureEntity("amf", "10:38", "10:40"),
                       new DepartureEntity("ut", "10:54", "10:59"),
                       new DepartureEntity("gd", "11:19", "11:20"),
                       new DepartureEntity("gvc", "11:41", "11:41"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "79", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "10:34", "10:34"),
                       new DepartureEntity("amf", "10:38", "10:40"),
                       new DepartureEntity("ut", "10:54", "10:59"),
                       new DepartureEntity("gd", "11:17", "11:19"),
                       new DepartureEntity("gvc", "11:40", "11:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "80", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "11:50", "11:50"),
                       new DepartureEntity("rta", "11:58", "11:58"),
                       new DepartureEntity("gd", "12:08", "12:09"),
                       new DepartureEntity("ut", "12:28", "12:36"),
                       new DepartureEntity("amf", "12:50", "12:53"),
                       new DepartureEntity("apd", "13:17", "13:18"),
                       new DepartureEntity("dv", "13:28", "13:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "81", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "11:50", "11:50"),
                       new DepartureEntity("rta", "11:58", "11:58"),
                       new DepartureEntity("gd", "12:08", "12:13"),
                       new DepartureEntity("ut", "12:31", "12:36"),
                       new DepartureEntity("amf", "12:50", "12:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "82", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "11:50", "11:50"),
                       new DepartureEntity("rta", "11:58", "11:58"),
                       new DepartureEntity("gd", "12:08", "12:14"),
                       new DepartureEntity("ut", "12:32", "12:37"),
                       new DepartureEntity("amf", "12:50", "12:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "83", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "11:50", "11:50"),
                       new DepartureEntity("rta", "11:58", "11:58"),
                       new DepartureEntity("gd", "12:08", "12:13"),
                       new DepartureEntity("ut", "12:31", "12:36"),
                       new DepartureEntity("amf", "12:50", "12:53"),
                       new DepartureEntity("apd", "13:17", "13:18"),
                       new DepartureEntity("dv", "13:28", "13:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "84", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "12:36", "12:36"),
                       new DepartureEntity("amf", "12:50", "12:53"),
                       new DepartureEntity("apd", "13:17", "13:18"),
                       new DepartureEntity("dv", "13:28", "13:30"),
                       new DepartureEntity("aml", "13:55", "13:56"),
                       new DepartureEntity("hgl", "14:07", "14:08"),
                       new DepartureEntity("es", "14:15", "14:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "85", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "11:53", "11:53"),
                       new DepartureEntity("gd", "12:10", "12:13"),
                       new DepartureEntity("ut", "12:31", "12:36"),
                       new DepartureEntity("amf", "12:50", "12:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "86", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "11:50", "11:50"),
                       new DepartureEntity("gd", "12:07", "12:13"),
                       new DepartureEntity("ut", "12:31", "12:36"),
                       new DepartureEntity("amf", "12:50", "12:53"),
                       new DepartureEntity("apd", "13:17", "13:18"),
                       new DepartureEntity("dv", "13:28", "13:30"),
                       new DepartureEntity("aml", "13:55", "13:56"),
                       new DepartureEntity("hgl", "14:07", "14:08"),
                       new DepartureEntity("es", "14:15", "14:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "87", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "11:53", "11:53"),
                       new DepartureEntity("gd", "12:10", "12:13"),
                       new DepartureEntity("ut", "12:31", "12:36"),
                       new DepartureEntity("amf", "12:50", "12:53"),
                       new DepartureEntity("apd", "13:17", "13:18"),
                       new DepartureEntity("dv", "13:28", "13:30"),
                       new DepartureEntity("aml", "13:55", "13:56"),
                       new DepartureEntity("hgl", "14:07", "14:08"),
                       new DepartureEntity("es", "14:15", "14:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "88", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "11:54", "11:54"),
                       new DepartureEntity("gd", "12:11", "12:12"),
                       new DepartureEntity("ut", "12:31", "12:36"),
                       new DepartureEntity("amf", "12:50", "12:53"),
                       new DepartureEntity("apd", "13:17", "13:18"),
                       new DepartureEntity("dv", "13:28", "13:30"),
                       new DepartureEntity("aml", "13:55", "13:56"),
                       new DepartureEntity("hgl", "14:07", "14:08"),
                       new DepartureEntity("es", "14:15", "14:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "89", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "11:53", "11:53"),
                       new DepartureEntity("gd", "12:13", "12:14"),
                       new DepartureEntity("ut", "12:32", "12:37"),
                       new DepartureEntity("amf", "12:50", "12:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "90", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "15:10", "15:10"),
                       new DepartureEntity("ut", "15:24", "15:29"),
                       new DepartureEntity("gd", "15:47", "15:52"),
                       new DepartureEntity("rta", "16:01", "16:01"),
                       new DepartureEntity("rtd", "16:10", "16:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "91", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "14:32", "14:32"),
                       new DepartureEntity("apd", "14:42", "14:43"),
                       new DepartureEntity("amf", "15:07", "15:10"),
                       new DepartureEntity("ut", "15:24", "15:29"),
                       new DepartureEntity("gd", "15:47", "15:52"),
                       new DepartureEntity("rta", "16:01", "16:01"),
                       new DepartureEntity("rtd", "16:10", "16:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "92", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "14:32", "14:32"),
                       new DepartureEntity("apd", "14:42", "14:43"),
                       new DepartureEntity("amf", "15:07", "15:10"),
                       new DepartureEntity("ut", "15:24", "15:29"),
                       new DepartureEntity("gd", "15:47", "15:52"),
                       new DepartureEntity("rta", "16:01", "16:01"),
                       new DepartureEntity("rtd", "16:10", "16:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "93", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "14:32", "14:32"),
                       new DepartureEntity("apd", "14:42", "14:43"),
                       new DepartureEntity("amf", "15:07", "15:10"),
                       new DepartureEntity("ut", "15:24", "15:32"),
                       new DepartureEntity("gd", "15:51", "15:52"),
                       new DepartureEntity("rta", "16:01", "16:01"),
                       new DepartureEntity("rtd", "16:10", "16:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "94", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "15:10", "15:10"),
                       new DepartureEntity("ut", "15:24", "15:29"),
                       new DepartureEntity("gd", "15:47", "15:49"),
                       new DepartureEntity("gvc", "16:07", "16:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "95", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "13:46", "13:46"),
                       new DepartureEntity("hgl", "13:53", "13:54"),
                       new DepartureEntity("aml", "14:05", "14:06"),
                       new DepartureEntity("dv", "14:29", "14:32"),
                       new DepartureEntity("apd", "14:42", "14:43"),
                       new DepartureEntity("amf", "15:07", "15:10"),
                       new DepartureEntity("ut", "15:24", "15:29"),
                       new DepartureEntity("gd", "15:47", "15:49"),
                       new DepartureEntity("gvc", "16:07", "16:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "96", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "13:46", "13:46"),
                       new DepartureEntity("hgl", "13:53", "13:54"),
                       new DepartureEntity("aml", "14:05", "14:06"),
                       new DepartureEntity("dv", "14:29", "14:32"),
                       new DepartureEntity("apd", "14:42", "14:43"),
                       new DepartureEntity("amf", "15:07", "15:10"),
                       new DepartureEntity("ut", "15:26", "15:26"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "97", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "13:46", "13:46"),
                       new DepartureEntity("hgl", "13:53", "13:54"),
                       new DepartureEntity("aml", "14:05", "14:06"),
                       new DepartureEntity("dv", "14:29", "14:32"),
                       new DepartureEntity("apd", "14:42", "14:43"),
                       new DepartureEntity("amf", "15:07", "15:10"),
                       new DepartureEntity("ut", "15:24", "15:29"),
                       new DepartureEntity("gd", "15:48", "15:49"),
                       new DepartureEntity("gvc", "16:07", "16:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "98", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "13:46", "13:46"),
                       new DepartureEntity("hgl", "13:53", "13:54"),
                       new DepartureEntity("aml", "14:05", "14:06"),
                       new DepartureEntity("dv", "14:29", "14:32"),
                       new DepartureEntity("apd", "14:42", "14:43"),
                       new DepartureEntity("amf", "15:07", "15:10"),
                       new DepartureEntity("ut", "15:24", "15:29"),
                       new DepartureEntity("gd", "15:48", "15:49"),
                       new DepartureEntity("gvc", "16:07", "16:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "99", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "13:46", "13:46"),
                       new DepartureEntity("hgl", "13:53", "13:54"),
                       new DepartureEntity("aml", "14:05", "14:06"),
                       new DepartureEntity("dv", "14:29", "14:32"),
                       new DepartureEntity("apd", "14:42", "14:43"),
                       new DepartureEntity("amf", "15:07", "15:10"),
                       new DepartureEntity("ut", "15:24", "15:29"),
                       new DepartureEntity("gd", "15:49", "15:50"),
                       new DepartureEntity("gvc", "16:11", "16:11"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "100", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "16:20", "16:20"),
                       new DepartureEntity("rta", "16:28", "16:28"),
                       new DepartureEntity("gd", "16:38", "16:39"),
                       new DepartureEntity("ut", "16:58", "17:06"),
                       new DepartureEntity("amf", "17:20", "17:25"),
                       new DepartureEntity("amfs", "17:29", "17:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "101", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "16:20", "16:20"),
                       new DepartureEntity("rta", "16:28", "16:28"),
                       new DepartureEntity("gd", "16:38", "16:43"),
                       new DepartureEntity("ut", "17:01", "17:06"),
                       new DepartureEntity("amf", "17:20", "17:25"),
                       new DepartureEntity("amfs", "17:29", "17:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "102", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "16:20", "16:20"),
                       new DepartureEntity("rta", "16:28", "16:28"),
                       new DepartureEntity("gd", "16:38", "16:43"),
                       new DepartureEntity("ut", "17:01", "17:06"),
                       new DepartureEntity("amf", "17:20", "17:25"),
                       new DepartureEntity("amfs", "17:29", "17:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "103", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "17:06", "17:06"),
                       new DepartureEntity("amf", "17:20", "17:20"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "104", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "16:20", "16:20"),
                       new DepartureEntity("gd", "16:37", "16:43"),
                       new DepartureEntity("ut", "17:01", "17:06"),
                       new DepartureEntity("amf", "17:20", "17:25"),
                       new DepartureEntity("amfs", "17:29", "17:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "105", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "16:23", "16:23"),
                       new DepartureEntity("gd", "16:40", "16:43"),
                       new DepartureEntity("ut", "17:01", "17:06"),
                       new DepartureEntity("amf", "17:20", "17:25"),
                       new DepartureEntity("amfs", "17:29", "17:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "106", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "16:24", "16:24"),
                       new DepartureEntity("gd", "16:41", "16:42"),
                       new DepartureEntity("ut", "17:01", "17:06"),
                       new DepartureEntity("amf", "17:20", "17:25"),
                       new DepartureEntity("amfs", "17:29", "17:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "107", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "16:23", "16:23"),
                       new DepartureEntity("gd", "16:40", "16:43"),
                       new DepartureEntity("ut", "17:01", "17:06"),
                       new DepartureEntity("amf", "17:20", "17:25"),
                       new DepartureEntity("amfs", "17:29", "17:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "108", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "17:34", "17:34"),
                       new DepartureEntity("amf", "17:38", "17:40"),
                       new DepartureEntity("ut", "17:54", "17:59"),
                       new DepartureEntity("gd", "18:17", "18:22"),
                       new DepartureEntity("rta", "18:31", "18:31"),
                       new DepartureEntity("rtd", "18:40", "18:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "109", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "17:34", "17:34"),
                       new DepartureEntity("amf", "17:38", "17:40"),
                       new DepartureEntity("ut", "17:54", "17:59"),
                       new DepartureEntity("gd", "18:17", "18:22"),
                       new DepartureEntity("rta", "18:31", "18:31"),
                       new DepartureEntity("rtd", "18:40", "18:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "110", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "17:34", "17:34"),
                       new DepartureEntity("amf", "17:38", "17:40"),
                       new DepartureEntity("ut", "17:54", "17:59"),
                       new DepartureEntity("gd", "18:17", "18:22"),
                       new DepartureEntity("rta", "18:31", "18:31"),
                       new DepartureEntity("rtd", "18:40", "18:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "111", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "17:34", "17:34"),
                       new DepartureEntity("amf", "17:38", "17:40"),
                       new DepartureEntity("ut", "17:54", "18:02"),
                       new DepartureEntity("gd", "18:21", "18:22"),
                       new DepartureEntity("rta", "18:31", "18:31"),
                       new DepartureEntity("rtd", "18:40", "18:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "112", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "17:40", "17:40"),
                       new DepartureEntity("ut", "17:56", "17:56"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "113", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "17:34", "17:34"),
                       new DepartureEntity("amf", "17:38", "17:40"),
                       new DepartureEntity("ut", "17:54", "17:59"),
                       new DepartureEntity("gd", "18:17", "18:19"),
                       new DepartureEntity("gvc", "18:37", "18:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "114", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "17:34", "17:34"),
                       new DepartureEntity("amf", "17:38", "17:40"),
                       new DepartureEntity("ut", "17:54", "17:59"),
                       new DepartureEntity("gd", "18:17", "18:19"),
                       new DepartureEntity("gvc", "18:37", "18:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "115", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "17:40", "17:40"),
                       new DepartureEntity("ut", "17:56", "17:56"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "116", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "17:34", "17:34"),
                       new DepartureEntity("amf", "17:38", "17:40"),
                       new DepartureEntity("ut", "17:54", "17:59"),
                       new DepartureEntity("gd", "18:18", "18:19"),
                       new DepartureEntity("gvc", "18:37", "18:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "117", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "17:34", "17:34"),
                       new DepartureEntity("amf", "17:38", "17:40"),
                       new DepartureEntity("ut", "17:54", "17:59"),
                       new DepartureEntity("gd", "18:18", "18:19"),
                       new DepartureEntity("gvc", "18:37", "18:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "118", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "17:34", "17:34"),
                       new DepartureEntity("amf", "17:38", "17:40"),
                       new DepartureEntity("ut", "17:54", "17:59"),
                       new DepartureEntity("gd", "18:19", "18:20"),
                       new DepartureEntity("gvc", "18:41", "18:41"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "119", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "17:34", "17:34"),
                       new DepartureEntity("amf", "17:38", "17:40"),
                       new DepartureEntity("ut", "17:54", "17:59"),
                       new DepartureEntity("gd", "18:19", "18:20"),
                       new DepartureEntity("gvc", "18:41", "18:41"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "120", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "18:50", "18:50"),
                       new DepartureEntity("rta", "18:58", "18:58"),
                       new DepartureEntity("gd", "19:08", "19:09"),
                       new DepartureEntity("ut", "19:28", "19:36"),
                       new DepartureEntity("amf", "19:50", "19:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "121", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "18:50", "18:50"),
                       new DepartureEntity("rta", "18:58", "18:58"),
                       new DepartureEntity("gd", "19:08", "19:13"),
                       new DepartureEntity("ut", "19:31", "19:36"),
                       new DepartureEntity("amf", "19:50", "19:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "122", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "18:50", "18:50"),
                       new DepartureEntity("rta", "18:58", "18:58"),
                       new DepartureEntity("gd", "19:08", "19:13"),
                       new DepartureEntity("ut", "19:31", "19:36"),
                       new DepartureEntity("amf", "19:50", "19:53"),
                       new DepartureEntity("apd", "20:17", "20:18"),
                       new DepartureEntity("dv", "20:28", "20:30"),
                       new DepartureEntity("aml", "20:55", "20:56"),
                       new DepartureEntity("hgl", "21:07", "21:08"),
                       new DepartureEntity("es", "21:15", "21:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "123", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "18:50", "18:50"),
                       new DepartureEntity("rta", "18:58", "18:58"),
                       new DepartureEntity("gd", "19:08", "19:13"),
                       new DepartureEntity("ut", "19:31", "19:36"),
                       new DepartureEntity("amf", "19:50", "19:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "124", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "19:36", "19:36"),
                       new DepartureEntity("amf", "19:50", "19:53"),
                       new DepartureEntity("apd", "20:17", "20:18"),
                       new DepartureEntity("dv", "20:28", "20:30"),
                       new DepartureEntity("aml", "20:55", "20:56"),
                       new DepartureEntity("hgl", "21:07", "21:08"),
                       new DepartureEntity("es", "21:15", "21:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "125", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "18:50", "18:50"),
                       new DepartureEntity("gd", "19:07", "19:13"),
                       new DepartureEntity("ut", "19:31", "19:36"),
                       new DepartureEntity("amf", "19:50", "19:53"),
                       new DepartureEntity("apd", "20:17", "20:18"),
                       new DepartureEntity("dv", "20:28", "20:30"),
                       new DepartureEntity("aml", "20:55", "20:56"),
                       new DepartureEntity("hgl", "21:07", "21:08"),
                       new DepartureEntity("es", "21:15", "21:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "126", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "18:50", "18:50"),
                       new DepartureEntity("gd", "19:07", "19:13"),
                       new DepartureEntity("ut", "19:31", "19:36"),
                       new DepartureEntity("amf", "19:50", "19:53"),
                       new DepartureEntity("apd", "20:17", "20:18"),
                       new DepartureEntity("dv", "20:28", "20:30"),
                       new DepartureEntity("aml", "20:55", "20:56"),
                       new DepartureEntity("hgl", "21:07", "21:08"),
                       new DepartureEntity("es", "21:15", "21:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "127", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "18:53", "18:53"),
                       new DepartureEntity("gd", "19:10", "19:13"),
                       new DepartureEntity("ut", "19:31", "19:36"),
                       new DepartureEntity("amf", "19:50", "19:53"),
                       new DepartureEntity("apd", "20:17", "20:18"),
                       new DepartureEntity("dv", "20:28", "20:30"),
                       new DepartureEntity("aml", "20:55", "20:56"),
                       new DepartureEntity("hgl", "21:07", "21:08"),
                       new DepartureEntity("es", "21:15", "21:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "128", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "18:54", "18:54"),
                       new DepartureEntity("gd", "19:11", "19:12"),
                       new DepartureEntity("ut", "19:31", "19:36"),
                       new DepartureEntity("amf", "19:50", "19:53"),
                       new DepartureEntity("apd", "20:17", "20:18"),
                       new DepartureEntity("dv", "20:28", "20:30"),
                       new DepartureEntity("aml", "20:55", "20:56"),
                       new DepartureEntity("hgl", "21:07", "21:08"),
                       new DepartureEntity("es", "21:15", "21:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "129", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "18:53", "18:53"),
                       new DepartureEntity("gd", "19:10", "19:13"),
                       new DepartureEntity("ut", "19:31", "19:36"),
                       new DepartureEntity("amf", "19:50", "19:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "130", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "18:53", "18:53"),
                       new DepartureEntity("gd", "19:10", "19:13"),
                       new DepartureEntity("ut", "19:31", "19:36"),
                       new DepartureEntity("amf", "19:50", "19:53"),
                       new DepartureEntity("apd", "20:17", "20:18"),
                       new DepartureEntity("dv", "20:28", "20:30"),
                       new DepartureEntity("aml", "20:55", "20:56"),
                       new DepartureEntity("hgl", "21:07", "21:08"),
                       new DepartureEntity("es", "21:15", "21:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "131", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "06:50", "06:50"),
                       new DepartureEntity("rta", "06:58", "06:58"),
                       new DepartureEntity("gd", "07:08", "07:09"),
                       new DepartureEntity("ut", "07:28", "07:36"),
                       new DepartureEntity("amf", "07:50", "07:53"),
                       new DepartureEntity("apd", "08:17", "08:18"),
                       new DepartureEntity("dv", "08:28", "08:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "132", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "06:50", "06:50"),
                       new DepartureEntity("rta", "06:58", "06:58"),
                       new DepartureEntity("gd", "07:08", "07:09"),
                       new DepartureEntity("ut", "07:28", "07:36"),
                       new DepartureEntity("amf", "07:50", "07:53"),
                       new DepartureEntity("apd", "08:17", "08:18"),
                       new DepartureEntity("dv", "08:28", "08:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "133", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "06:50", "06:50"),
                       new DepartureEntity("rta", "06:58", "06:58"),
                       new DepartureEntity("gd", "07:08", "07:13"),
                       new DepartureEntity("ut", "07:31", "07:36"),
                       new DepartureEntity("amf", "07:50", "07:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "134", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "06:50", "06:50"),
                       new DepartureEntity("rta", "06:58", "06:58"),
                       new DepartureEntity("gd", "07:08", "07:13"),
                       new DepartureEntity("ut", "07:31", "07:36"),
                       new DepartureEntity("amf", "07:50", "07:53"),
                       new DepartureEntity("apd", "08:17", "08:18"),
                       new DepartureEntity("dv", "08:28", "08:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "135", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "06:50", "06:50"),
                       new DepartureEntity("gd", "07:07", "07:13"),
                       new DepartureEntity("ut", "07:31", "07:36"),
                       new DepartureEntity("amf", "07:50", "07:53"),
                       new DepartureEntity("apd", "08:17", "08:18"),
                       new DepartureEntity("dv", "08:28", "08:30"),
                       new DepartureEntity("aml", "08:55", "08:56"),
                       new DepartureEntity("hgl", "09:07", "09:08"),
                       new DepartureEntity("es", "09:15", "09:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "136", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "06:53", "06:53"),
                       new DepartureEntity("gd", "07:10", "07:13"),
                       new DepartureEntity("ut", "07:31", "07:36"),
                       new DepartureEntity("amf", "07:50", "07:53"),
                       new DepartureEntity("apd", "08:17", "08:18"),
                       new DepartureEntity("dv", "08:28", "08:30"),
                       new DepartureEntity("aml", "08:55", "08:56"),
                       new DepartureEntity("hgl", "09:07", "09:08"),
                       new DepartureEntity("es", "09:15", "09:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "137", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "06:54", "06:54"),
                       new DepartureEntity("gd", "07:11", "07:12"),
                       new DepartureEntity("ut", "07:31", "07:36"),
                       new DepartureEntity("amf", "07:50", "07:53"),
                       new DepartureEntity("apd", "08:17", "08:18"),
                       new DepartureEntity("dv", "08:28", "08:30"),
                       new DepartureEntity("aml", "08:55", "08:56"),
                       new DepartureEntity("hgl", "09:07", "09:08"),
                       new DepartureEntity("es", "09:15", "09:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "138", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "07:36", "07:36"),
                       new DepartureEntity("amf", "07:50", "07:53"),
                       new DepartureEntity("apd", "08:17", "08:18"),
                       new DepartureEntity("dv", "08:28", "08:30"),
                       new DepartureEntity("aml", "08:55", "08:56"),
                       new DepartureEntity("hgl", "09:07", "09:08"),
                       new DepartureEntity("es", "09:15", "09:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "139", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "06:53", "06:53"),
                       new DepartureEntity("gd", "07:10", "07:13"),
                       new DepartureEntity("ut", "07:31", "07:36"),
                       new DepartureEntity("amf", "07:50", "07:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "140", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "07:53", "07:53"),
                       new DepartureEntity("apd", "08:17", "08:18"),
                       new DepartureEntity("dv", "08:28", "08:30"),
                       new DepartureEntity("aml", "08:55", "08:56"),
                       new DepartureEntity("hgl", "09:07", "09:08"),
                       new DepartureEntity("es", "09:15", "09:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "141", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "07:53", "07:53"),
                       new DepartureEntity("apd", "08:17", "08:18"),
                       new DepartureEntity("dv", "08:28", "08:30"),
                       new DepartureEntity("aml", "08:55", "08:56"),
                       new DepartureEntity("hgl", "09:07", "09:08"),
                       new DepartureEntity("es", "09:15", "09:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "142", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "06:54", "06:54"),
                       new DepartureEntity("gd", "07:11", "07:12"),
                       new DepartureEntity("ut", "07:31", "07:36"),
                       new DepartureEntity("amf", "07:50", "07:53"),
                       new DepartureEntity("apd", "08:17", "08:18"),
                       new DepartureEntity("dv", "08:28", "08:30"),
                       new DepartureEntity("aml", "08:55", "08:56"),
                       new DepartureEntity("hgl", "09:07", "09:08"),
                       new DepartureEntity("es", "09:15", "09:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "143", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "10:10", "10:10"),
                       new DepartureEntity("ut", "10:24", "10:29"),
                       new DepartureEntity("gd", "10:47", "10:52"),
                       new DepartureEntity("rta", "11:01", "11:01"),
                       new DepartureEntity("rtd", "11:10", "11:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "144", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "09:32", "09:32"),
                       new DepartureEntity("apd", "09:42", "09:43"),
                       new DepartureEntity("amf", "10:07", "10:10"),
                       new DepartureEntity("ut", "10:24", "10:29"),
                       new DepartureEntity("gd", "10:47", "10:52"),
                       new DepartureEntity("rta", "11:01", "11:01"),
                       new DepartureEntity("rtd", "11:10", "11:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "145", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "09:32", "09:32"),
                       new DepartureEntity("apd", "09:42", "09:43"),
                       new DepartureEntity("amf", "10:07", "10:10"),
                       new DepartureEntity("ut", "10:24", "10:29"),
                       new DepartureEntity("gd", "10:47", "10:52"),
                       new DepartureEntity("rta", "11:01", "11:01"),
                       new DepartureEntity("rtd", "11:10", "11:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "146", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "09:32", "09:32"),
                       new DepartureEntity("apd", "09:42", "09:43"),
                       new DepartureEntity("amf", "10:07", "10:10"),
                       new DepartureEntity("ut", "10:24", "10:32"),
                       new DepartureEntity("gd", "10:51", "10:52"),
                       new DepartureEntity("rta", "11:01", "11:01"),
                       new DepartureEntity("rtd", "11:10", "11:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "147", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "10:10", "10:10"),
                       new DepartureEntity("ut", "10:24", "10:29"),
                       new DepartureEntity("gd", "10:47", "10:49"),
                       new DepartureEntity("gvc", "11:07", "11:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "148", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "08:46", "08:46"),
                       new DepartureEntity("hgl", "08:53", "08:54"),
                       new DepartureEntity("aml", "09:05", "09:06"),
                       new DepartureEntity("dv", "09:29", "09:32"),
                       new DepartureEntity("apd", "09:42", "09:43"),
                       new DepartureEntity("amf", "10:07", "10:10"),
                       new DepartureEntity("ut", "10:24", "10:29"),
                       new DepartureEntity("gd", "10:49", "10:50"),
                       new DepartureEntity("gvc", "11:11", "11:11"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "149", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "08:46", "08:46"),
                       new DepartureEntity("hgl", "08:53", "08:54"),
                       new DepartureEntity("aml", "09:05", "09:06"),
                       new DepartureEntity("dv", "09:29", "09:32"),
                       new DepartureEntity("apd", "09:42", "09:43"),
                       new DepartureEntity("amf", "10:07", "10:10"),
                       new DepartureEntity("ut", "10:24", "10:29"),
                       new DepartureEntity("gd", "10:48", "10:49"),
                       new DepartureEntity("gvc", "11:07", "11:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "150", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "08:46", "08:46"),
                       new DepartureEntity("hgl", "08:53", "08:54"),
                       new DepartureEntity("aml", "09:05", "09:06"),
                       new DepartureEntity("dv", "09:29", "09:32"),
                       new DepartureEntity("apd", "09:42", "09:43"),
                       new DepartureEntity("amf", "10:07", "10:10"),
                       new DepartureEntity("ut", "10:26", "10:26"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "151", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "08:46", "08:46"),
                       new DepartureEntity("hgl", "08:53", "08:54"),
                       new DepartureEntity("aml", "09:05", "09:06"),
                       new DepartureEntity("dv", "09:29", "09:32"),
                       new DepartureEntity("apd", "09:42", "09:43"),
                       new DepartureEntity("amf", "10:07", "10:10"),
                       new DepartureEntity("ut", "10:26", "10:26"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "152", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "08:46", "08:46"),
                       new DepartureEntity("hgl", "08:53", "08:54"),
                       new DepartureEntity("aml", "09:05", "09:06"),
                       new DepartureEntity("dv", "09:29", "09:32"),
                       new DepartureEntity("apd", "09:42", "09:43"),
                       new DepartureEntity("amf", "10:07", "10:10"),
                       new DepartureEntity("ut", "10:24", "10:29"),
                       new DepartureEntity("gd", "10:47", "10:49"),
                       new DepartureEntity("gvc", "11:07", "11:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "153", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "08:46", "08:46"),
                       new DepartureEntity("hgl", "08:53", "08:54"),
                       new DepartureEntity("aml", "09:05", "09:06"),
                       new DepartureEntity("dv", "09:29", "09:32"),
                       new DepartureEntity("apd", "09:42", "09:43"),
                       new DepartureEntity("amf", "10:07", "10:10"),
                       new DepartureEntity("ut", "10:24", "10:29"),
                       new DepartureEntity("gd", "10:47", "10:49"),
                       new DepartureEntity("gvc", "11:07", "11:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "154", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "10:10", "10:10"),
                       new DepartureEntity("ut", "10:24", "10:29"),
                       new DepartureEntity("gd", "10:47", "10:49"),
                       new DepartureEntity("gvc", "11:10", "11:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "155", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "08:46", "08:46"),
                       new DepartureEntity("hgl", "08:53", "08:54"),
                       new DepartureEntity("aml", "09:05", "09:06"),
                       new DepartureEntity("dv", "09:29", "09:32"),
                       new DepartureEntity("apd", "09:42", "09:43"),
                       new DepartureEntity("amf", "10:07", "10:10"),
                       new DepartureEntity("ut", "10:24", "10:29"),
                       new DepartureEntity("gd", "10:48", "10:49"),
                       new DepartureEntity("gvc", "11:07", "11:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "156", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "08:46", "08:46"),
                       new DepartureEntity("hgl", "08:53", "08:54"),
                       new DepartureEntity("aml", "09:05", "09:06"),
                       new DepartureEntity("dv", "09:29", "09:32"),
                       new DepartureEntity("apd", "09:42", "09:43"),
                       new DepartureEntity("amf", "10:07", "10:10"),
                       new DepartureEntity("ut", "10:24", "10:29"),
                       new DepartureEntity("gd", "10:49", "10:50"),
                       new DepartureEntity("gvc", "11:11", "11:11"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "157", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "11:20", "11:20"),
                       new DepartureEntity("rta", "11:28", "11:28"),
                       new DepartureEntity("gd", "11:38", "11:39"),
                       new DepartureEntity("ut", "11:58", "12:06"),
                       new DepartureEntity("amf", "12:20", "12:25"),
                       new DepartureEntity("amfs", "12:29", "12:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "158", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "11:20", "11:20"),
                       new DepartureEntity("rta", "11:28", "11:28"),
                       new DepartureEntity("gd", "11:38", "11:43"),
                       new DepartureEntity("ut", "12:01", "12:06"),
                       new DepartureEntity("amf", "12:20", "12:25"),
                       new DepartureEntity("amfs", "12:29", "12:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "159", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "11:20", "11:20"),
                       new DepartureEntity("rta", "11:28", "11:28"),
                       new DepartureEntity("gd", "11:38", "11:44"),
                       new DepartureEntity("ut", "12:01", "12:06"),
                       new DepartureEntity("amf", "12:20", "12:25"),
                       new DepartureEntity("amfs", "12:29", "12:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "160", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "11:20", "11:20"),
                       new DepartureEntity("rta", "11:28", "11:28"),
                       new DepartureEntity("gd", "11:38", "11:43"),
                       new DepartureEntity("ut", "12:01", "12:06"),
                       new DepartureEntity("amf", "12:20", "12:25"),
                       new DepartureEntity("amfs", "12:29", "12:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "161", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "12:06", "12:06"),
                       new DepartureEntity("amf", "12:20", "12:20"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "162", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "11:23", "11:23"),
                       new DepartureEntity("gd", "11:40", "11:43"),
                       new DepartureEntity("ut", "12:01", "12:06"),
                       new DepartureEntity("amf", "12:20", "12:25"),
                       new DepartureEntity("amfs", "12:29", "12:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "163", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "11:20", "11:20"),
                       new DepartureEntity("gd", "11:37", "11:43"),
                       new DepartureEntity("ut", "12:01", "12:06"),
                       new DepartureEntity("amf", "12:20", "12:25"),
                       new DepartureEntity("amfs", "12:29", "12:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "164", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "11:23", "11:23"),
                       new DepartureEntity("gd", "11:40", "11:43"),
                       new DepartureEntity("ut", "12:01", "12:06"),
                       new DepartureEntity("amf", "12:20", "12:25"),
                       new DepartureEntity("amfs", "12:29", "12:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "165", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "11:24", "11:24"),
                       new DepartureEntity("gd", "11:41", "11:42"),
                       new DepartureEntity("ut", "12:01", "12:06"),
                       new DepartureEntity("amf", "12:20", "12:25"),
                       new DepartureEntity("amfs", "12:29", "12:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "166", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "11:23", "11:23"),
                       new DepartureEntity("gd", "11:43", "11:44"),
                       new DepartureEntity("ut", "12:01", "12:06"),
                       new DepartureEntity("amf", "12:20", "12:25"),
                       new DepartureEntity("amfs", "12:29", "12:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "167", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "12:06", "12:06"),
                       new DepartureEntity("amf", "12:20", "12:20"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "168", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "12:34", "12:34"),
                       new DepartureEntity("amf", "12:38", "12:40"),
                       new DepartureEntity("ut", "12:54", "12:59"),
                       new DepartureEntity("gd", "13:17", "13:22"),
                       new DepartureEntity("rta", "13:31", "13:31"),
                       new DepartureEntity("rtd", "13:40", "13:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "169", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "12:34", "12:34"),
                       new DepartureEntity("amf", "12:38", "12:40"),
                       new DepartureEntity("ut", "12:54", "12:59"),
                       new DepartureEntity("gd", "13:17", "13:22"),
                       new DepartureEntity("rta", "13:31", "13:31"),
                       new DepartureEntity("rtd", "13:40", "13:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "170", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "12:34", "12:34"),
                       new DepartureEntity("amf", "12:38", "12:40"),
                       new DepartureEntity("ut", "12:54", "12:59"),
                       new DepartureEntity("gd", "13:17", "13:22"),
                       new DepartureEntity("rta", "13:31", "13:31"),
                       new DepartureEntity("rtd", "13:40", "13:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "171", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "12:34", "12:34"),
                       new DepartureEntity("amf", "12:38", "12:40"),
                       new DepartureEntity("ut", "12:54", "12:59"),
                       new DepartureEntity("gd", "13:17", "13:22"),
                       new DepartureEntity("rta", "13:31", "13:31"),
                       new DepartureEntity("rtd", "13:40", "13:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "172", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "12:34", "12:34"),
                       new DepartureEntity("amf", "12:38", "12:40"),
                       new DepartureEntity("ut", "12:54", "13:02"),
                       new DepartureEntity("gd", "13:21", "13:22"),
                       new DepartureEntity("rta", "13:31", "13:31"),
                       new DepartureEntity("rtd", "13:41", "13:41"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "173", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "12:34", "12:34"),
                       new DepartureEntity("amf", "12:38", "12:40"),
                       new DepartureEntity("ut", "12:54", "13:02"),
                       new DepartureEntity("gd", "13:21", "13:22"),
                       new DepartureEntity("rta", "13:31", "13:31"),
                       new DepartureEntity("rtd", "13:40", "13:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "174", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "12:40", "12:40"),
                       new DepartureEntity("ut", "12:56", "12:56"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "175", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "12:34", "12:34"),
                       new DepartureEntity("amf", "12:38", "12:40"),
                       new DepartureEntity("ut", "12:54", "12:59"),
                       new DepartureEntity("gd", "13:18", "13:19"),
                       new DepartureEntity("gvc", "13:37", "13:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "176", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "12:34", "12:34"),
                       new DepartureEntity("amf", "12:38", "12:40"),
                       new DepartureEntity("ut", "12:54", "12:59"),
                       new DepartureEntity("gd", "13:17", "13:19"),
                       new DepartureEntity("gvc", "13:37", "13:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "177", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "12:40", "12:40"),
                       new DepartureEntity("ut", "12:56", "12:56"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "178", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "12:34", "12:34"),
                       new DepartureEntity("amf", "12:38", "12:40"),
                       new DepartureEntity("ut", "12:54", "12:59"),
                       new DepartureEntity("gd", "13:17", "13:19"),
                       new DepartureEntity("gvc", "13:37", "13:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "179", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "12:34", "12:34"),
                       new DepartureEntity("amf", "12:38", "12:40"),
                       new DepartureEntity("ut", "12:54", "12:59"),
                       new DepartureEntity("gd", "13:17", "13:19"),
                       new DepartureEntity("gvc", "13:40", "13:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "180", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "12:34", "12:34"),
                       new DepartureEntity("amf", "12:38", "12:40"),
                       new DepartureEntity("ut", "12:54", "12:59"),
                       new DepartureEntity("gd", "13:18", "13:19"),
                       new DepartureEntity("gvc", "13:37", "13:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "181", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "12:34", "12:34"),
                       new DepartureEntity("amf", "12:38", "12:40"),
                       new DepartureEntity("ut", "12:54", "12:59"),
                       new DepartureEntity("gd", "13:19", "13:20"),
                       new DepartureEntity("gvc", "13:41", "13:41"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "182", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "13:50", "13:50"),
                       new DepartureEntity("rta", "13:58", "13:58"),
                       new DepartureEntity("gd", "14:08", "14:09"),
                       new DepartureEntity("ut", "14:28", "14:36"),
                       new DepartureEntity("amf", "14:50", "14:53"),
                       new DepartureEntity("apd", "15:17", "15:18"),
                       new DepartureEntity("dv", "15:28", "15:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "183", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "13:50", "13:50"),
                       new DepartureEntity("rta", "13:58", "13:58"),
                       new DepartureEntity("gd", "14:08", "14:09"),
                       new DepartureEntity("ut", "14:28", "14:36"),
                       new DepartureEntity("amf", "14:50", "14:53"),
                       new DepartureEntity("apd", "15:17", "15:18"),
                       new DepartureEntity("dv", "15:28", "15:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "184", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "13:50", "13:50"),
                       new DepartureEntity("rta", "13:58", "13:58"),
                       new DepartureEntity("gd", "14:08", "14:13"),
                       new DepartureEntity("ut", "14:31", "14:36"),
                       new DepartureEntity("amf", "14:50", "14:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "185", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "13:50", "13:50"),
                       new DepartureEntity("rta", "13:58", "13:58"),
                       new DepartureEntity("gd", "14:08", "14:14"),
                       new DepartureEntity("ut", "14:32", "14:37"),
                       new DepartureEntity("amf", "14:50", "14:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "186", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "13:50", "13:50"),
                       new DepartureEntity("rta", "13:58", "13:58"),
                       new DepartureEntity("gd", "14:08", "14:13"),
                       new DepartureEntity("ut", "14:31", "14:36"),
                       new DepartureEntity("amf", "14:50", "14:53"),
                       new DepartureEntity("apd", "15:17", "15:18"),
                       new DepartureEntity("dv", "15:28", "15:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "187", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "14:36", "14:36"),
                       new DepartureEntity("amf", "14:50", "14:53"),
                       new DepartureEntity("apd", "15:17", "15:18"),
                       new DepartureEntity("dv", "15:28", "15:30"),
                       new DepartureEntity("aml", "15:55", "15:56"),
                       new DepartureEntity("hgl", "16:07", "16:08"),
                       new DepartureEntity("es", "16:15", "16:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "188", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "13:53", "13:53"),
                       new DepartureEntity("gd", "14:10", "14:13"),
                       new DepartureEntity("ut", "14:31", "14:36"),
                       new DepartureEntity("amf", "14:50", "14:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "189", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "13:50", "13:50"),
                       new DepartureEntity("gd", "14:07", "14:13"),
                       new DepartureEntity("ut", "14:31", "14:36"),
                       new DepartureEntity("amf", "14:50", "14:53"),
                       new DepartureEntity("apd", "15:17", "15:18"),
                       new DepartureEntity("dv", "15:28", "15:30"),
                       new DepartureEntity("aml", "15:55", "15:56"),
                       new DepartureEntity("hgl", "16:07", "16:08"),
                       new DepartureEntity("es", "16:15", "16:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "190", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "13:53", "13:53"),
                       new DepartureEntity("gd", "14:10", "14:13"),
                       new DepartureEntity("ut", "14:31", "14:36"),
                       new DepartureEntity("amf", "14:50", "14:53"),
                       new DepartureEntity("apd", "15:17", "15:18"),
                       new DepartureEntity("dv", "15:28", "15:30"),
                       new DepartureEntity("aml", "15:55", "15:56"),
                       new DepartureEntity("hgl", "16:07", "16:08"),
                       new DepartureEntity("es", "16:15", "16:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "191", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "13:54", "13:54"),
                       new DepartureEntity("gd", "14:11", "14:12"),
                       new DepartureEntity("ut", "14:31", "14:36"),
                       new DepartureEntity("amf", "14:50", "14:53"),
                       new DepartureEntity("apd", "15:17", "15:18"),
                       new DepartureEntity("dv", "15:28", "15:30"),
                       new DepartureEntity("aml", "15:55", "15:56"),
                       new DepartureEntity("hgl", "16:07", "16:08"),
                       new DepartureEntity("es", "16:15", "16:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "192", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "13:53", "13:53"),
                       new DepartureEntity("gd", "14:13", "14:14"),
                       new DepartureEntity("ut", "14:32", "14:37"),
                       new DepartureEntity("amf", "14:50", "14:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "193", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "18:10", "18:10"),
                       new DepartureEntity("ut", "18:24", "18:29"),
                       new DepartureEntity("gd", "18:47", "18:52"),
                       new DepartureEntity("rta", "19:01", "19:01"),
                       new DepartureEntity("rtd", "19:10", "19:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "194", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "18:10", "18:10"),
                       new DepartureEntity("ut", "18:24", "18:29"),
                       new DepartureEntity("gd", "18:47", "18:52"),
                       new DepartureEntity("rta", "19:01", "19:01"),
                       new DepartureEntity("rtd", "19:10", "19:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "195", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "17:32", "17:32"),
                       new DepartureEntity("apd", "17:42", "17:43"),
                       new DepartureEntity("amf", "18:07", "18:10"),
                       new DepartureEntity("ut", "18:24", "18:29"),
                       new DepartureEntity("gd", "18:47", "18:52"),
                       new DepartureEntity("rta", "19:01", "19:01"),
                       new DepartureEntity("rtd", "19:10", "19:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "196", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "17:32", "17:32"),
                       new DepartureEntity("apd", "17:42", "17:43"),
                       new DepartureEntity("amf", "18:07", "18:10"),
                       new DepartureEntity("ut", "18:24", "18:29"),
                       new DepartureEntity("gd", "18:47", "18:52"),
                       new DepartureEntity("rta", "19:01", "19:01"),
                       new DepartureEntity("rtd", "19:10", "19:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "197", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "17:32", "17:32"),
                       new DepartureEntity("apd", "17:42", "17:43"),
                       new DepartureEntity("amf", "18:07", "18:10"),
                       new DepartureEntity("ut", "18:24", "18:32"),
                       new DepartureEntity("gd", "18:51", "18:52"),
                       new DepartureEntity("rta", "19:01", "19:01"),
                       new DepartureEntity("rtd", "19:10", "19:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "198", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "17:32", "17:32"),
                       new DepartureEntity("apd", "17:42", "17:43"),
                       new DepartureEntity("amf", "18:07", "18:10"),
                       new DepartureEntity("ut", "18:24", "18:32"),
                       new DepartureEntity("gd", "18:51", "18:52"),
                       new DepartureEntity("rta", "19:01", "19:01"),
                       new DepartureEntity("rtd", "19:10", "19:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "199", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "18:10", "18:10"),
                       new DepartureEntity("ut", "18:24", "18:29"),
                       new DepartureEntity("gd", "18:47", "18:49"),
                       new DepartureEntity("gvc", "19:07", "19:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "200", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "16:46", "16:46"),
                       new DepartureEntity("hgl", "16:53", "16:54"),
                       new DepartureEntity("aml", "17:05", "17:06"),
                       new DepartureEntity("dv", "17:29", "17:32"),
                       new DepartureEntity("apd", "17:42", "17:43"),
                       new DepartureEntity("amf", "18:07", "18:10"),
                       new DepartureEntity("ut", "18:24", "18:29"),
                       new DepartureEntity("gd", "18:48", "18:49"),
                       new DepartureEntity("gvc", "19:07", "19:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "201", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "16:46", "16:46"),
                       new DepartureEntity("hgl", "16:53", "16:54"),
                       new DepartureEntity("aml", "17:05", "17:06"),
                       new DepartureEntity("dv", "17:29", "17:32"),
                       new DepartureEntity("apd", "17:42", "17:43"),
                       new DepartureEntity("amf", "18:07", "18:10"),
                       new DepartureEntity("ut", "18:24", "18:29"),
                       new DepartureEntity("gd", "18:47", "18:49"),
                       new DepartureEntity("gvc", "19:07", "19:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "202", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "16:46", "16:46"),
                       new DepartureEntity("hgl", "16:53", "16:54"),
                       new DepartureEntity("aml", "17:05", "17:06"),
                       new DepartureEntity("dv", "17:29", "17:32"),
                       new DepartureEntity("apd", "17:42", "17:43"),
                       new DepartureEntity("amf", "18:07", "18:10"),
                       new DepartureEntity("ut", "18:26", "18:26"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "203", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "16:46", "16:46"),
                       new DepartureEntity("hgl", "16:53", "16:54"),
                       new DepartureEntity("aml", "17:05", "17:06"),
                       new DepartureEntity("dv", "17:29", "17:32"),
                       new DepartureEntity("apd", "17:42", "17:43"),
                       new DepartureEntity("amf", "18:07", "18:10"),
                       new DepartureEntity("ut", "18:24", "18:29"),
                       new DepartureEntity("gd", "18:48", "18:49"),
                       new DepartureEntity("gvc", "19:07", "19:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "204", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "16:46", "16:46"),
                       new DepartureEntity("hgl", "16:53", "16:54"),
                       new DepartureEntity("aml", "17:05", "17:06"),
                       new DepartureEntity("dv", "17:29", "17:32"),
                       new DepartureEntity("apd", "17:42", "17:43"),
                       new DepartureEntity("amf", "18:07", "18:10"),
                       new DepartureEntity("ut", "18:24", "18:29"),
                       new DepartureEntity("gd", "18:49", "18:50"),
                       new DepartureEntity("gvc", "19:11", "19:11"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "205", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "18:10", "18:10"),
                       new DepartureEntity("ut", "18:24", "18:29"),
                       new DepartureEntity("gd", "18:47", "18:49"),
                       new DepartureEntity("gvc", "19:07", "19:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "206", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "16:46", "16:46"),
                       new DepartureEntity("hgl", "16:53", "16:54"),
                       new DepartureEntity("aml", "17:05", "17:06"),
                       new DepartureEntity("dv", "17:29", "17:32"),
                       new DepartureEntity("apd", "17:42", "17:43"),
                       new DepartureEntity("amf", "18:07", "18:10"),
                       new DepartureEntity("ut", "18:24", "18:29"),
                       new DepartureEntity("gd", "18:48", "18:49"),
                       new DepartureEntity("gvc", "19:07", "19:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "207", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "16:46", "16:46"),
                       new DepartureEntity("hgl", "16:53", "16:54"),
                       new DepartureEntity("aml", "17:05", "17:06"),
                       new DepartureEntity("dv", "17:29", "17:32"),
                       new DepartureEntity("apd", "17:42", "17:43"),
                       new DepartureEntity("amf", "18:07", "18:10"),
                       new DepartureEntity("ut", "18:24", "18:29"),
                       new DepartureEntity("gd", "18:48", "18:49"),
                       new DepartureEntity("gvc", "19:07", "19:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "208", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "16:46", "16:46"),
                       new DepartureEntity("hgl", "16:53", "16:54"),
                       new DepartureEntity("aml", "17:05", "17:06"),
                       new DepartureEntity("dv", "17:29", "17:32"),
                       new DepartureEntity("apd", "17:42", "17:43"),
                       new DepartureEntity("amf", "18:07", "18:10"),
                       new DepartureEntity("ut", "18:24", "18:29"),
                       new DepartureEntity("gd", "18:49", "18:50"),
                       new DepartureEntity("gvc", "19:11", "19:11"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "209", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "19:20", "19:20"),
                       new DepartureEntity("rta", "19:28", "19:28"),
                       new DepartureEntity("gd", "19:38", "19:39"),
                       new DepartureEntity("ut", "19:58", "20:06"),
                       new DepartureEntity("amf", "20:20", "20:20"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "210", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "19:20", "19:20"),
                       new DepartureEntity("rta", "19:28", "19:28"),
                       new DepartureEntity("gd", "19:38", "19:39"),
                       new DepartureEntity("ut", "19:58", "20:06"),
                       new DepartureEntity("amf", "20:20", "20:20"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "211", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "19:20", "19:20"),
                       new DepartureEntity("rta", "19:28", "19:28"),
                       new DepartureEntity("gd", "19:38", "19:39"),
                       new DepartureEntity("ut", "19:58", "20:06"),
                       new DepartureEntity("amf", "20:20", "20:20"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "212", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "19:20", "19:20"),
                       new DepartureEntity("rta", "19:28", "19:28"),
                       new DepartureEntity("gd", "19:38", "19:43"),
                       new DepartureEntity("ut", "20:01", "20:06"),
                       new DepartureEntity("amf", "20:20", "20:20"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "213", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "19:20", "19:20"),
                       new DepartureEntity("rta", "19:28", "19:28"),
                       new DepartureEntity("gd", "19:38", "19:43"),
                       new DepartureEntity("ut", "20:01", "20:06"),
                       new DepartureEntity("amf", "20:20", "20:20"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "214", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "19:20", "19:20"),
                       new DepartureEntity("rta", "19:28", "19:28"),
                       new DepartureEntity("gd", "19:38", "19:43"),
                       new DepartureEntity("ut", "20:01", "20:06"),
                       new DepartureEntity("amf", "20:20", "20:25"),
                       new DepartureEntity("amfs", "20:29", "20:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "215", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "20:06", "20:06"),
                       new DepartureEntity("amf", "20:20", "20:20"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "216", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "19:20", "19:20"),
                       new DepartureEntity("gd", "19:37", "19:43"),
                       new DepartureEntity("ut", "20:01", "20:06"),
                       new DepartureEntity("amf", "20:20", "20:25"),
                       new DepartureEntity("amfs", "20:29", "20:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "217", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "19:20", "19:20"),
                       new DepartureEntity("gd", "19:37", "19:43"),
                       new DepartureEntity("ut", "20:01", "20:06"),
                       new DepartureEntity("amf", "20:20", "20:25"),
                       new DepartureEntity("amfs", "20:29", "20:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "218", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "19:23", "19:23"),
                       new DepartureEntity("gd", "19:40", "19:43"),
                       new DepartureEntity("ut", "20:01", "20:06"),
                       new DepartureEntity("amf", "20:20", "20:25"),
                       new DepartureEntity("amfs", "20:29", "20:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "219", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "19:24", "19:24"),
                       new DepartureEntity("gd", "19:41", "19:42"),
                       new DepartureEntity("ut", "20:01", "20:06"),
                       new DepartureEntity("amf", "20:20", "20:25"),
                       new DepartureEntity("amfs", "20:29", "20:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "220", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "20:06", "20:06"),
                       new DepartureEntity("amf", "20:20", "20:20"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "221", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "19:24", "19:24"),
                       new DepartureEntity("gd", "19:41", "19:42"),
                       new DepartureEntity("ut", "20:01", "20:06"),
                       new DepartureEntity("amf", "20:20", "20:25"),
                       new DepartureEntity("amfs", "20:29", "20:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "222", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "19:24", "19:24"),
                       new DepartureEntity("gd", "19:41", "19:42"),
                       new DepartureEntity("ut", "20:01", "20:06"),
                       new DepartureEntity("amf", "20:20", "20:25"),
                       new DepartureEntity("amfs", "20:29", "20:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "223", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "19:23", "19:23"),
                       new DepartureEntity("gd", "19:40", "19:43"),
                       new DepartureEntity("ut", "20:01", "20:06"),
                       new DepartureEntity("amf", "20:20", "20:25"),
                       new DepartureEntity("amfs", "20:29", "20:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "224", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "19:23", "19:23"),
                       new DepartureEntity("gd", "19:40", "19:43"),
                       new DepartureEntity("ut", "20:01", "20:06"),
                       new DepartureEntity("amf", "20:20", "20:25"),
                       new DepartureEntity("amfs", "20:29", "20:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "225", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("bgn", "06:22", "06:22"),
                       new DepartureEntity("rsd", "06:34", "06:40"),
                       new DepartureEntity("ddr", "07:02", "07:05"),
                       new DepartureEntity("rtb", "07:16", "07:16"),
                       new DepartureEntity("rtd", "07:19", "07:22"),
                       new DepartureEntity("sdm", "07:26", "07:26"),
                       new DepartureEntity("dt", "07:34", "07:34"),
                       new DepartureEntity("gv", "07:41", "07:43"),
                       new DepartureEntity("laa", "07:45", "07:46"),
                       new DepartureEntity("ledn", "07:55", "07:57"),
                       new DepartureEntity("shl", "08:14", "08:14"),
                       new DepartureEntity("asdl", "08:21", "08:21"),
                       new DepartureEntity("ass", "08:25", "08:25"),
                       new DepartureEntity("asd", "08:32", "08:37"),
                       new DepartureEntity("alm", "08:58", "09:00"),
                       new DepartureEntity("lls", "09:15", "09:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "226", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("bgn", "06:22", "06:22"),
                       new DepartureEntity("rsd", "06:34", "06:40"),
                       new DepartureEntity("ddr", "07:02", "07:05"),
                       new DepartureEntity("rtb", "07:16", "07:16"),
                       new DepartureEntity("rtd", "07:19", "07:22"),
                       new DepartureEntity("sdm", "07:26", "07:26"),
                       new DepartureEntity("dt", "07:34", "07:34"),
                       new DepartureEntity("gv", "07:41", "07:43"),
                       new DepartureEntity("laa", "07:45", "07:46"),
                       new DepartureEntity("ledn", "07:55", "07:57"),
                       new DepartureEntity("shl", "08:14", "08:14"),
                       new DepartureEntity("asdl", "08:21", "08:21"),
                       new DepartureEntity("ass", "08:25", "08:25"),
                       new DepartureEntity("asd", "08:32", "08:37"),
                       new DepartureEntity("alm", "08:58", "09:00"),
                       new DepartureEntity("lls", "09:15", "09:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "227", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("vs", "05:35", "05:35"),
                       new DepartureEntity("vss", "05:38", "05:38"),
                       new DepartureEntity("mdb", "05:42", "05:42"),
                       new DepartureEntity("arn", "05:46", "05:46"),
                       new DepartureEntity("gs", "05:57", "05:58"),
                       new DepartureEntity("bzl", "06:02", "06:02"),
                       new DepartureEntity("krg", "06:07", "06:07"),
                       new DepartureEntity("kbd", "06:12", "06:12"),
                       new DepartureEntity("rb", "06:16", "06:16"),
                       new DepartureEntity("bgn", "06:26", "06:27"),
                       new DepartureEntity("rsd", "06:37", "06:40"),
                       new DepartureEntity("ddr", "07:02", "07:05"),
                       new DepartureEntity("rtb", "07:16", "07:16"),
                       new DepartureEntity("rtd", "07:19", "07:22"),
                       new DepartureEntity("sdm", "07:26", "07:26"),
                       new DepartureEntity("dt", "07:34", "07:34"),
                       new DepartureEntity("gv", "07:41", "07:43"),
                       new DepartureEntity("laa", "07:45", "07:46"),
                       new DepartureEntity("ledn", "07:55", "07:57"),
                       new DepartureEntity("shl", "08:14", "08:14"),
                       new DepartureEntity("asdl", "08:21", "08:21"),
                       new DepartureEntity("ass", "08:25", "08:25"),
                       new DepartureEntity("asd", "08:32", "08:37"),
                       new DepartureEntity("alm", "08:58", "09:00"),
                       new DepartureEntity("lls", "09:15", "09:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "228", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("vs", "05:35", "05:35"),
                       new DepartureEntity("vss", "05:38", "05:38"),
                       new DepartureEntity("mdb", "05:42", "05:42"),
                       new DepartureEntity("arn", "05:46", "05:46"),
                       new DepartureEntity("gs", "05:57", "05:58"),
                       new DepartureEntity("bzl", "06:02", "06:02"),
                       new DepartureEntity("krg", "06:07", "06:07"),
                       new DepartureEntity("kbd", "06:12", "06:12"),
                       new DepartureEntity("rb", "06:16", "06:16"),
                       new DepartureEntity("bgn", "06:26", "06:27"),
                       new DepartureEntity("rsd", "06:37", "06:40"),
                       new DepartureEntity("ddr", "07:02", "07:05"),
                       new DepartureEntity("rtb", "07:16", "07:16"),
                       new DepartureEntity("rtd", "07:19", "07:22"),
                       new DepartureEntity("sdm", "07:26", "07:26"),
                       new DepartureEntity("dt", "07:34", "07:34"),
                       new DepartureEntity("gv", "07:41", "07:43"),
                       new DepartureEntity("laa", "07:45", "07:46"),
                       new DepartureEntity("ledn", "07:55", "07:57"),
                       new DepartureEntity("shl", "08:14", "08:14"),
                       new DepartureEntity("asdl", "08:21", "08:21"),
                       new DepartureEntity("ass", "08:25", "08:25"),
                       new DepartureEntity("asd", "08:32", "08:37"),
                       new DepartureEntity("alm", "08:58", "09:00"),
                       new DepartureEntity("lls", "09:15", "09:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "229", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rsd", "06:40", "06:40"),
                       new DepartureEntity("ddr", "07:02", "07:05"),
                       new DepartureEntity("rtb", "07:16", "07:16"),
                       new DepartureEntity("rtd", "07:19", "07:22"),
                       new DepartureEntity("sdm", "07:26", "07:26"),
                       new DepartureEntity("dt", "07:34", "07:34"),
                       new DepartureEntity("gv", "07:41", "07:43"),
                       new DepartureEntity("laa", "07:45", "07:46"),
                       new DepartureEntity("ledn", "07:55", "07:57"),
                       new DepartureEntity("shl", "08:14", "08:14"),
                       new DepartureEntity("asdl", "08:21", "08:21"),
                       new DepartureEntity("ass", "08:25", "08:25"),
                       new DepartureEntity("asd", "08:31", "08:31"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "230", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("vs", "05:35", "05:35"),
                       new DepartureEntity("vss", "05:38", "05:38"),
                       new DepartureEntity("mdb", "05:42", "05:42"),
                       new DepartureEntity("arn", "05:46", "05:46"),
                       new DepartureEntity("gs", "05:57", "05:58"),
                       new DepartureEntity("bzl", "06:02", "06:02"),
                       new DepartureEntity("krg", "06:07", "06:07"),
                       new DepartureEntity("kbd", "06:12", "06:12"),
                       new DepartureEntity("rb", "06:16", "06:16"),
                       new DepartureEntity("bgn", "06:26", "06:27"),
                       new DepartureEntity("rsd", "06:37", "06:40"),
                       new DepartureEntity("ddr", "07:02", "07:05"),
                       new DepartureEntity("rtb", "07:16", "07:16"),
                       new DepartureEntity("rtd", "07:19", "07:22"),
                       new DepartureEntity("sdm", "07:26", "07:26"),
                       new DepartureEntity("dt", "07:34", "07:34"),
                       new DepartureEntity("gv", "07:41", "07:43"),
                       new DepartureEntity("laa", "07:45", "07:46"),
                       new DepartureEntity("ledn", "07:55", "07:57"),
                       new DepartureEntity("shl", "08:14", "08:14"),
                       new DepartureEntity("asdl", "08:21", "08:21"),
                       new DepartureEntity("ass", "08:25", "08:25"),
                       new DepartureEntity("asd", "08:32", "08:37"),
                       new DepartureEntity("alm", "08:58", "09:00"),
                       new DepartureEntity("lls", "09:15", "09:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "231", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rsd", "06:40", "06:40"),
                       new DepartureEntity("ddr", "07:02", "07:05"),
                       new DepartureEntity("rtb", "07:16", "07:16"),
                       new DepartureEntity("rtd", "07:19", "07:22"),
                       new DepartureEntity("sdm", "07:26", "07:26"),
                       new DepartureEntity("dt", "07:34", "07:34"),
                       new DepartureEntity("gv", "07:41", "07:43"),
                       new DepartureEntity("laa", "07:45", "07:46"),
                       new DepartureEntity("ledn", "07:55", "07:57"),
                       new DepartureEntity("shl", "08:14", "08:14"),
                       new DepartureEntity("asdl", "08:21", "08:21"),
                       new DepartureEntity("ass", "08:25", "08:25"),
                       new DepartureEntity("asd", "08:32", "08:37"),
                       new DepartureEntity("alm", "08:58", "09:00"),
                       new DepartureEntity("lls", "09:15", "09:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "232", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("bgn", "06:52", "06:52"),
                       new DepartureEntity("rsd", "07:04", "07:10"),
                       new DepartureEntity("ddr", "07:32", "07:35"),
                       new DepartureEntity("rtb", "07:46", "07:46"),
                       new DepartureEntity("rtd", "07:49", "07:52"),
                       new DepartureEntity("sdm", "07:56", "07:56"),
                       new DepartureEntity("dt", "08:04", "08:04"),
                       new DepartureEntity("gv", "08:11", "08:13"),
                       new DepartureEntity("laa", "08:15", "08:16"),
                       new DepartureEntity("ledn", "08:25", "08:27"),
                       new DepartureEntity("shl", "08:44", "08:44"),
                       new DepartureEntity("asdl", "08:51", "08:51"),
                       new DepartureEntity("ass", "08:55", "08:55"),
                       new DepartureEntity("asd", "09:01", "09:07"),
                       new DepartureEntity("alm", "09:28", "09:30"),
                       new DepartureEntity("lls", "09:45", "09:45"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "233", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("vs", "06:05", "06:05"),
                       new DepartureEntity("vss", "06:08", "06:08"),
                       new DepartureEntity("mdb", "06:12", "06:12"),
                       new DepartureEntity("arn", "06:16", "06:16"),
                       new DepartureEntity("gs", "06:27", "06:28"),
                       new DepartureEntity("bzl", "06:32", "06:32"),
                       new DepartureEntity("krg", "06:37", "06:37"),
                       new DepartureEntity("kbd", "06:42", "06:42"),
                       new DepartureEntity("rb", "06:46", "06:46"),
                       new DepartureEntity("bgn", "06:56", "06:57"),
                       new DepartureEntity("rsd", "07:07", "07:10"),
                       new DepartureEntity("ddr", "07:32", "07:35"),
                       new DepartureEntity("rtb", "07:46", "07:46"),
                       new DepartureEntity("rtd", "07:49", "07:52"),
                       new DepartureEntity("sdm", "07:56", "07:56"),
                       new DepartureEntity("dt", "08:04", "08:04"),
                       new DepartureEntity("gv", "08:11", "08:13"),
                       new DepartureEntity("laa", "08:15", "08:16"),
                       new DepartureEntity("ledn", "08:25", "08:27"),
                       new DepartureEntity("shl", "08:44", "08:44"),
                       new DepartureEntity("asdl", "08:51", "08:51"),
                       new DepartureEntity("ass", "08:55", "08:55"),
                       new DepartureEntity("asd", "09:01", "09:07"),
                       new DepartureEntity("alm", "09:28", "09:30"),
                       new DepartureEntity("lls", "09:45", "09:45"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "234", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("vs", "06:05", "06:05"),
                       new DepartureEntity("vss", "06:08", "06:08"),
                       new DepartureEntity("mdb", "06:12", "06:12"),
                       new DepartureEntity("arn", "06:16", "06:16"),
                       new DepartureEntity("gs", "06:27", "06:28"),
                       new DepartureEntity("bzl", "06:32", "06:32"),
                       new DepartureEntity("krg", "06:37", "06:37"),
                       new DepartureEntity("kbd", "06:42", "06:42"),
                       new DepartureEntity("rb", "06:46", "06:46"),
                       new DepartureEntity("bgn", "06:56", "06:57"),
                       new DepartureEntity("rsd", "07:07", "07:10"),
                       new DepartureEntity("ddr", "07:32", "07:35"),
                       new DepartureEntity("rtb", "07:46", "07:46"),
                       new DepartureEntity("rtd", "07:49", "07:52"),
                       new DepartureEntity("sdm", "07:56", "07:56"),
                       new DepartureEntity("dt", "08:04", "08:04"),
                       new DepartureEntity("gv", "08:11", "08:13"),
                       new DepartureEntity("laa", "08:15", "08:16"),
                       new DepartureEntity("ledn", "08:25", "08:27"),
                       new DepartureEntity("shl", "08:44", "08:44"),
                       new DepartureEntity("asdl", "08:51", "08:51"),
                       new DepartureEntity("ass", "08:55", "08:55"),
                       new DepartureEntity("asd", "09:01", "09:07"),
                       new DepartureEntity("alm", "09:28", "09:30"),
                       new DepartureEntity("lls", "09:45", "09:45"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "235", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("vs", "06:05", "06:05"),
                       new DepartureEntity("vss", "06:08", "06:08"),
                       new DepartureEntity("mdb", "06:12", "06:12"),
                       new DepartureEntity("arn", "06:16", "06:16"),
                       new DepartureEntity("gs", "06:27", "06:28"),
                       new DepartureEntity("bzl", "06:32", "06:32"),
                       new DepartureEntity("krg", "06:37", "06:37"),
                       new DepartureEntity("kbd", "06:42", "06:42"),
                       new DepartureEntity("rb", "06:46", "06:46"),
                       new DepartureEntity("bgn", "06:56", "06:57"),
                       new DepartureEntity("rsd", "07:07", "07:10"),
                       new DepartureEntity("ddr", "07:32", "07:35"),
                       new DepartureEntity("rtb", "07:46", "07:46"),
                       new DepartureEntity("rtd", "07:49", "07:52"),
                       new DepartureEntity("sdm", "07:56", "07:56"),
                       new DepartureEntity("dt", "08:04", "08:04"),
                       new DepartureEntity("gv", "08:11", "08:13"),
                       new DepartureEntity("laa", "08:15", "08:16"),
                       new DepartureEntity("ledn", "08:25", "08:27"),
                       new DepartureEntity("shl", "08:44", "08:44"),
                       new DepartureEntity("asdl", "08:51", "08:51"),
                       new DepartureEntity("ass", "08:55", "08:55"),
                       new DepartureEntity("asd", "09:01", "09:01"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "236", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("vs", "06:05", "06:05"),
                       new DepartureEntity("vss", "06:08", "06:08"),
                       new DepartureEntity("mdb", "06:12", "06:12"),
                       new DepartureEntity("arn", "06:16", "06:16"),
                       new DepartureEntity("gs", "06:27", "06:28"),
                       new DepartureEntity("bzl", "06:32", "06:32"),
                       new DepartureEntity("krg", "06:37", "06:37"),
                       new DepartureEntity("kbd", "06:42", "06:42"),
                       new DepartureEntity("rb", "06:46", "06:46"),
                       new DepartureEntity("bgn", "06:56", "06:57"),
                       new DepartureEntity("rsd", "07:07", "07:10"),
                       new DepartureEntity("ddr", "07:32", "07:35"),
                       new DepartureEntity("rtb", "07:46", "07:46"),
                       new DepartureEntity("rtd", "07:49", "07:52"),
                       new DepartureEntity("sdm", "07:56", "07:56"),
                       new DepartureEntity("dt", "08:04", "08:04"),
                       new DepartureEntity("gv", "08:11", "08:13"),
                       new DepartureEntity("laa", "08:15", "08:16"),
                       new DepartureEntity("ledn", "08:25", "08:27"),
                       new DepartureEntity("shl", "08:44", "08:44"),
                       new DepartureEntity("asdl", "08:51", "08:51"),
                       new DepartureEntity("ass", "08:55", "08:55"),
                       new DepartureEntity("asd", "09:01", "09:07"),
                       new DepartureEntity("alm", "09:28", "09:30"),
                       new DepartureEntity("lls", "09:45", "09:45"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "237", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("vs", "06:05", "06:05"),
                       new DepartureEntity("vss", "06:08", "06:08"),
                       new DepartureEntity("mdb", "06:12", "06:12"),
                       new DepartureEntity("arn", "06:16", "06:16"),
                       new DepartureEntity("gs", "06:27", "06:28"),
                       new DepartureEntity("bzl", "06:32", "06:32"),
                       new DepartureEntity("krg", "06:37", "06:37"),
                       new DepartureEntity("kbd", "06:42", "06:42"),
                       new DepartureEntity("rb", "06:46", "06:46"),
                       new DepartureEntity("bgn", "06:56", "06:57"),
                       new DepartureEntity("rsd", "07:07", "07:10"),
                       new DepartureEntity("ddr", "07:32", "07:35"),
                       new DepartureEntity("rtb", "07:46", "07:46"),
                       new DepartureEntity("rtd", "07:49", "07:52"),
                       new DepartureEntity("sdm", "07:56", "07:56"),
                       new DepartureEntity("dt", "08:04", "08:04"),
                       new DepartureEntity("gv", "08:11", "08:13"),
                       new DepartureEntity("laa", "08:15", "08:16"),
                       new DepartureEntity("ledn", "08:25", "08:27"),
                       new DepartureEntity("shl", "08:44", "08:44"),
                       new DepartureEntity("asdl", "08:51", "08:51"),
                       new DepartureEntity("ass", "08:55", "08:55"),
                       new DepartureEntity("asd", "09:01", "09:07"),
                       new DepartureEntity("alm", "09:28", "09:30"),
                       new DepartureEntity("lls", "09:45", "09:45"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "238", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("bgn", "07:22", "07:22"),
                       new DepartureEntity("rsd", "07:34", "07:40"),
                       new DepartureEntity("ddr", "08:02", "08:05"),
                       new DepartureEntity("rtb", "08:16", "08:16"),
                       new DepartureEntity("rtd", "08:19", "08:22"),
                       new DepartureEntity("sdm", "08:26", "08:26"),
                       new DepartureEntity("dt", "08:34", "08:34"),
                       new DepartureEntity("gv", "08:41", "08:43"),
                       new DepartureEntity("laa", "08:45", "08:46"),
                       new DepartureEntity("ledn", "08:55", "08:57"),
                       new DepartureEntity("shl", "09:14", "09:14"),
                       new DepartureEntity("asdl", "09:21", "09:21"),
                       new DepartureEntity("ass", "09:25", "09:25"),
                       new DepartureEntity("asd", "09:32", "09:37"),
                       new DepartureEntity("alm", "09:58", "10:00"),
                       new DepartureEntity("lls", "10:15", "10:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "239", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("bgn", "07:22", "07:22"),
                       new DepartureEntity("rsd", "07:34", "07:40"),
                       new DepartureEntity("ddr", "08:02", "08:05"),
                       new DepartureEntity("rtb", "08:16", "08:16"),
                       new DepartureEntity("rtd", "08:19", "08:22"),
                       new DepartureEntity("sdm", "08:26", "08:26"),
                       new DepartureEntity("dt", "08:34", "08:34"),
                       new DepartureEntity("gv", "08:41", "08:43"),
                       new DepartureEntity("laa", "08:45", "08:46"),
                       new DepartureEntity("ledn", "08:55", "08:57"),
                       new DepartureEntity("shl", "09:14", "09:14"),
                       new DepartureEntity("asdl", "09:21", "09:21"),
                       new DepartureEntity("ass", "09:25", "09:25"),
                       new DepartureEntity("asd", "09:32", "09:37"),
                       new DepartureEntity("alm", "09:58", "10:00"),
                       new DepartureEntity("lls", "10:15", "10:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "240", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("vs", "06:35", "06:35"),
                       new DepartureEntity("vss", "06:38", "06:38"),
                       new DepartureEntity("mdb", "06:42", "06:42"),
                       new DepartureEntity("arn", "06:46", "06:46"),
                       new DepartureEntity("gs", "06:57", "06:58"),
                       new DepartureEntity("bzl", "07:02", "07:02"),
                       new DepartureEntity("krg", "07:07", "07:07"),
                       new DepartureEntity("kbd", "07:12", "07:12"),
                       new DepartureEntity("rb", "07:16", "07:16"),
                       new DepartureEntity("bgn", "07:26", "07:27"),
                       new DepartureEntity("rsd", "07:37", "07:40"),
                       new DepartureEntity("ddr", "08:02", "08:05"),
                       new DepartureEntity("rtb", "08:16", "08:16"),
                       new DepartureEntity("rtd", "08:19", "08:22"),
                       new DepartureEntity("sdm", "08:26", "08:26"),
                       new DepartureEntity("dt", "08:34", "08:34"),
                       new DepartureEntity("gv", "08:41", "08:43"),
                       new DepartureEntity("laa", "08:45", "08:46"),
                       new DepartureEntity("ledn", "08:55", "08:57"),
                       new DepartureEntity("shl", "09:14", "09:14"),
                       new DepartureEntity("asdl", "09:21", "09:21"),
                       new DepartureEntity("ass", "09:25", "09:25"),
                       new DepartureEntity("asd", "09:31", "09:31"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "241", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("vs", "06:35", "06:35"),
                       new DepartureEntity("vss", "06:38", "06:38"),
                       new DepartureEntity("mdb", "06:42", "06:42"),
                       new DepartureEntity("arn", "06:46", "06:46"),
                       new DepartureEntity("gs", "06:57", "06:58"),
                       new DepartureEntity("bzl", "07:02", "07:02"),
                       new DepartureEntity("krg", "07:07", "07:07"),
                       new DepartureEntity("kbd", "07:12", "07:12"),
                       new DepartureEntity("rb", "07:16", "07:16"),
                       new DepartureEntity("bgn", "07:26", "07:27"),
                       new DepartureEntity("rsd", "07:37", "07:40"),
                       new DepartureEntity("ddr", "08:02", "08:05"),
                       new DepartureEntity("rtb", "08:16", "08:16"),
                       new DepartureEntity("rtd", "08:19", "08:22"),
                       new DepartureEntity("sdm", "08:26", "08:26"),
                       new DepartureEntity("dt", "08:34", "08:34"),
                       new DepartureEntity("gv", "08:41", "08:43"),
                       new DepartureEntity("laa", "08:45", "08:46"),
                       new DepartureEntity("ledn", "08:55", "08:57"),
                       new DepartureEntity("shl", "09:14", "09:14"),
                       new DepartureEntity("asdl", "09:21", "09:21"),
                       new DepartureEntity("ass", "09:25", "09:25"),
                       new DepartureEntity("asd", "09:32", "09:37"),
                       new DepartureEntity("alm", "09:58", "10:00"),
                       new DepartureEntity("lls", "10:15", "10:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "242", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("vs", "06:35", "06:35"),
                       new DepartureEntity("vss", "06:38", "06:38"),
                       new DepartureEntity("mdb", "06:42", "06:42"),
                       new DepartureEntity("arn", "06:46", "06:46"),
                       new DepartureEntity("gs", "06:57", "06:58"),
                       new DepartureEntity("bzl", "07:02", "07:02"),
                       new DepartureEntity("krg", "07:07", "07:07"),
                       new DepartureEntity("kbd", "07:12", "07:12"),
                       new DepartureEntity("rb", "07:16", "07:16"),
                       new DepartureEntity("bgn", "07:26", "07:27"),
                       new DepartureEntity("rsd", "07:37", "07:40"),
                       new DepartureEntity("ddr", "08:02", "08:05"),
                       new DepartureEntity("rtb", "08:16", "08:16"),
                       new DepartureEntity("rtd", "08:19", "08:22"),
                       new DepartureEntity("sdm", "08:26", "08:26"),
                       new DepartureEntity("dt", "08:34", "08:34"),
                       new DepartureEntity("gv", "08:41", "08:43"),
                       new DepartureEntity("laa", "08:45", "08:46"),
                       new DepartureEntity("ledn", "08:55", "08:57"),
                       new DepartureEntity("shl", "09:14", "09:14"),
                       new DepartureEntity("asdl", "09:21", "09:21"),
                       new DepartureEntity("ass", "09:25", "09:25"),
                       new DepartureEntity("asd", "09:32", "09:37"),
                       new DepartureEntity("alm", "09:58", "10:00"),
                       new DepartureEntity("lls", "10:15", "10:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "243", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("vs", "06:35", "06:35"),
                       new DepartureEntity("vss", "06:38", "06:38"),
                       new DepartureEntity("mdb", "06:42", "06:42"),
                       new DepartureEntity("arn", "06:46", "06:46"),
                       new DepartureEntity("gs", "06:57", "06:58"),
                       new DepartureEntity("bzl", "07:02", "07:02"),
                       new DepartureEntity("krg", "07:07", "07:07"),
                       new DepartureEntity("kbd", "07:12", "07:12"),
                       new DepartureEntity("rb", "07:16", "07:16"),
                       new DepartureEntity("bgn", "07:26", "07:27"),
                       new DepartureEntity("rsd", "07:37", "07:40"),
                       new DepartureEntity("ddr", "08:02", "08:05"),
                       new DepartureEntity("rtb", "08:16", "08:16"),
                       new DepartureEntity("rtd", "08:19", "08:22"),
                       new DepartureEntity("sdm", "08:26", "08:26"),
                       new DepartureEntity("dt", "08:34", "08:34"),
                       new DepartureEntity("gv", "08:41", "08:43"),
                       new DepartureEntity("laa", "08:45", "08:46"),
                       new DepartureEntity("ledn", "08:55", "08:57"),
                       new DepartureEntity("shl", "09:14", "09:14"),
                       new DepartureEntity("asdl", "09:21", "09:21"),
                       new DepartureEntity("ass", "09:25", "09:25"),
                       new DepartureEntity("asd", "09:32", "09:37"),
                       new DepartureEntity("alm", "09:58", "10:00"),
                       new DepartureEntity("lls", "10:15", "10:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "244", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "02:32", "02:32"),
                       new DepartureEntity("gd", "02:50", "02:57"),
                       new DepartureEntity("gv", "03:16", "03:23"),
                       new DepartureEntity("ledn", "03:36", "03:38"),
                       new DepartureEntity("shl", "03:56", "04:00"),
                       new DepartureEntity("asd", "04:14", "04:17"),
                       new DepartureEntity("ut", "04:57", "04:57"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "245", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "02:32", "02:32"),
                       new DepartureEntity("gd", "02:50", "02:57"),
                       new DepartureEntity("gv", "03:16", "03:23"),
                       new DepartureEntity("ledn", "03:36", "03:38"),
                       new DepartureEntity("shl", "03:56", "04:00"),
                       new DepartureEntity("asd", "04:14", "04:17"),
                       new DepartureEntity("ut", "04:57", "04:57"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "246", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "02:32", "02:32"),
                       new DepartureEntity("gd", "02:50", "02:57"),
                       new DepartureEntity("gv", "03:16", "03:23"),
                       new DepartureEntity("ledn", "03:36", "03:38"),
                       new DepartureEntity("shl", "03:56", "04:00"),
                       new DepartureEntity("asd", "04:14", "04:17"),
                       new DepartureEntity("ut", "04:57", "04:57"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "247", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "02:32", "02:32"),
                       new DepartureEntity("gd", "02:50", "02:57"),
                       new DepartureEntity("gv", "03:16", "03:23"),
                       new DepartureEntity("ledn", "03:36", "03:38"),
                       new DepartureEntity("shl", "03:56", "04:00"),
                       new DepartureEntity("asd", "04:14", "04:17"),
                       new DepartureEntity("ut", "04:58", "04:58"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "248", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "02:32", "02:32"),
                       new DepartureEntity("gd", "02:50", "02:57"),
                       new DepartureEntity("gv", "03:16", "03:23"),
                       new DepartureEntity("ledn", "03:36", "03:38"),
                       new DepartureEntity("shl", "03:56", "04:00"),
                       new DepartureEntity("asd", "04:14", "04:17"),
                       new DepartureEntity("ut", "04:58", "04:58"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "249", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "02:32", "02:32"),
                       new DepartureEntity("gd", "02:50", "02:57"),
                       new DepartureEntity("gv", "03:16", "03:23"),
                       new DepartureEntity("ledn", "03:36", "03:38"),
                       new DepartureEntity("shl", "03:56", "04:00"),
                       new DepartureEntity("asd", "04:14", "04:17"),
                       new DepartureEntity("ut", "04:58", "04:58"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "250", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "02:32", "02:32"),
                       new DepartureEntity("gd", "02:50", "02:57"),
                       new DepartureEntity("gv", "03:22", "03:23"),
                       new DepartureEntity("ledn", "03:36", "03:38"),
                       new DepartureEntity("shl", "03:56", "04:00"),
                       new DepartureEntity("asd", "04:14", "04:17"),
                       new DepartureEntity("ut", "04:58", "04:58"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "251", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "01:30", "01:30"),
                       new DepartureEntity("tb", "02:00", "02:02"),
                       new DepartureEntity("bd", "02:18", "02:19"),
                       new DepartureEntity("ddr", "02:40", "02:41"),
                       new DepartureEntity("rtd", "02:55", "03:02"),
                       new DepartureEntity("dt", "03:14", "03:14"),
                       new DepartureEntity("gv", "03:22", "03:23"),
                       new DepartureEntity("ledn", "03:36", "03:38"),
                       new DepartureEntity("shl", "03:56", "04:00"),
                       new DepartureEntity("asd", "04:14", "04:17"),
                       new DepartureEntity("ut", "04:51", "04:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "252", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "01:30", "01:30"),
                       new DepartureEntity("tb", "02:00", "02:02"),
                       new DepartureEntity("bd", "02:18", "02:19"),
                       new DepartureEntity("ddr", "02:40", "02:41"),
                       new DepartureEntity("rtd", "02:55", "03:02"),
                       new DepartureEntity("dt", "03:14", "03:14"),
                       new DepartureEntity("gv", "03:22", "03:23"),
                       new DepartureEntity("ledn", "03:36", "03:38"),
                       new DepartureEntity("shl", "03:56", "04:00"),
                       new DepartureEntity("asd", "04:14", "04:15"),
                       new DepartureEntity("ut", "04:51", "04:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "253", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "01:30", "01:30"),
                       new DepartureEntity("tb", "02:00", "02:02"),
                       new DepartureEntity("bd", "02:18", "02:19"),
                       new DepartureEntity("ddr", "02:40", "02:41"),
                       new DepartureEntity("rtd", "02:55", "03:02"),
                       new DepartureEntity("dt", "03:14", "03:14"),
                       new DepartureEntity("gv", "03:22", "03:23"),
                       new DepartureEntity("ledn", "03:36", "03:38"),
                       new DepartureEntity("shl", "03:56", "04:00"),
                       new DepartureEntity("asd", "04:14", "04:17"),
                       new DepartureEntity("ut", "04:51", "04:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "254", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "01:30", "01:30"),
                       new DepartureEntity("tb", "02:00", "02:02"),
                       new DepartureEntity("bd", "02:18", "02:19"),
                       new DepartureEntity("ddr", "02:40", "02:41"),
                       new DepartureEntity("rtd", "02:55", "03:02"),
                       new DepartureEntity("dt", "03:14", "03:14"),
                       new DepartureEntity("gv", "03:22", "03:23"),
                       new DepartureEntity("ledn", "03:36", "03:38"),
                       new DepartureEntity("shl", "03:56", "04:00"),
                       new DepartureEntity("asd", "04:14", "04:17"),
                       new DepartureEntity("ut", "04:51", "04:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "255", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "01:30", "01:30"),
                       new DepartureEntity("tb", "02:00", "02:02"),
                       new DepartureEntity("bd", "02:18", "02:19"),
                       new DepartureEntity("ddr", "02:40", "02:41"),
                       new DepartureEntity("rtd", "02:55", "03:02"),
                       new DepartureEntity("dt", "03:14", "03:14"),
                       new DepartureEntity("gv", "03:22", "03:23"),
                       new DepartureEntity("ledn", "03:36", "03:38"),
                       new DepartureEntity("shl", "03:56", "04:00"),
                       new DepartureEntity("asd", "04:14", "04:15"),
                       new DepartureEntity("ut", "04:51", "04:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "256", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "01:30", "01:30"),
                       new DepartureEntity("tb", "02:00", "02:02"),
                       new DepartureEntity("bd", "02:18", "02:19"),
                       new DepartureEntity("ddr", "02:40", "02:41"),
                       new DepartureEntity("rtd", "02:55", "03:02"),
                       new DepartureEntity("dt", "03:14", "03:14"),
                       new DepartureEntity("gv", "03:22", "03:23"),
                       new DepartureEntity("ledn", "03:36", "03:38"),
                       new DepartureEntity("shl", "03:56", "04:00"),
                       new DepartureEntity("asd", "04:14", "04:17"),
                       new DepartureEntity("ut", "04:51", "04:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "257", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "03:02", "03:02"),
                       new DepartureEntity("dt", "03:14", "03:14"),
                       new DepartureEntity("gv", "03:22", "03:23"),
                       new DepartureEntity("ledn", "03:38", "03:39"),
                       new DepartureEntity("shl", "03:56", "04:00"),
                       new DepartureEntity("asd", "04:14", "04:17"),
                       new DepartureEntity("ut", "04:51", "04:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "258", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "03:02", "03:02"),
                       new DepartureEntity("dt", "03:14", "03:14"),
                       new DepartureEntity("gv", "03:22", "03:26"),
                       new DepartureEntity("ledn", "03:40", "03:41"),
                       new DepartureEntity("shl", "03:58", "04:01"),
                       new DepartureEntity("asd", "04:14", "04:17"),
                       new DepartureEntity("ut", "04:51", "04:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "259", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "03:02", "03:02"),
                       new DepartureEntity("dt", "03:14", "03:14"),
                       new DepartureEntity("gv", "03:22", "03:23"),
                       new DepartureEntity("ledn", "03:38", "03:39"),
                       new DepartureEntity("asd", "04:14", "04:17"),
                       new DepartureEntity("asb", "04:28", "04:30"),
                       new DepartureEntity("ut", "04:51", "04:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "260", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dt", "03:14", "03:14"),
                       new DepartureEntity("gv", "03:22", "03:23"),
                       new DepartureEntity("ledn", "03:36", "03:38"),
                       new DepartureEntity("shl", "03:56", "04:00"),
                       new DepartureEntity("asd", "04:14", "04:15"),
                       new DepartureEntity("ut", "04:51", "04:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "261", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "03:02", "03:02"),
                       new DepartureEntity("dt", "03:14", "03:14"),
                       new DepartureEntity("gv", "03:22", "03:23"),
                       new DepartureEntity("ledn", "03:36", "03:38"),
                       new DepartureEntity("asd", "04:08", "04:16"),
                       new DepartureEntity("ut", "04:51", "04:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "262", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "03:02", "03:02"),
                       new DepartureEntity("dt", "03:14", "03:14"),
                       new DepartureEntity("gv", "03:22", "03:23"),
                       new DepartureEntity("ledn", "03:36", "03:38"),
                       new DepartureEntity("asd", "04:14", "04:17"),
                       new DepartureEntity("asb", "04:28", "04:30"),
                       new DepartureEntity("ut", "04:51", "04:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "263", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "03:02", "03:02"),
                       new DepartureEntity("dt", "03:14", "03:14"),
                       new DepartureEntity("gv", "03:22", "03:23"),
                       new DepartureEntity("ledn", "03:38", "03:39"),
                       new DepartureEntity("shl", "03:56", "04:00"),
                       new DepartureEntity("asd", "04:14", "04:17"),
                       new DepartureEntity("ut", "04:51", "04:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "264", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "03:02", "03:02"),
                       new DepartureEntity("dt", "03:14", "03:14"),
                       new DepartureEntity("gv", "03:22", "03:26"),
                       new DepartureEntity("ledn", "03:40", "03:41"),
                       new DepartureEntity("shl", "03:58", "04:01"),
                       new DepartureEntity("asd", "04:14", "04:17"),
                       new DepartureEntity("ut", "04:51", "04:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "265", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "03:02", "03:02"),
                       new DepartureEntity("dt", "03:14", "03:14"),
                       new DepartureEntity("gv", "03:22", "03:23"),
                       new DepartureEntity("ledn", "03:38", "03:39"),
                       new DepartureEntity("asd", "04:14", "04:17"),
                       new DepartureEntity("asb", "04:28", "04:30"),
                       new DepartureEntity("ut", "04:51", "04:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "266", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "03:02", "03:02"),
                       new DepartureEntity("dt", "03:14", "03:14"),
                       new DepartureEntity("gv", "03:22", "03:26"),
                       new DepartureEntity("ledn", "03:40", "03:41"),
                       new DepartureEntity("shl", "03:58", "04:01"),
                       new DepartureEntity("asd", "04:14", "04:17"),
                       new DepartureEntity("ut", "04:51", "04:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "267", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "01:35", "01:35"),
                       new DepartureEntity("tb", "02:00", "02:02"),
                       new DepartureEntity("bd", "02:18", "02:19"),
                       new DepartureEntity("ddr", "02:40", "02:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "268", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "01:30", "01:30"),
                       new DepartureEntity("tb", "02:00", "02:02"),
                       new DepartureEntity("bd", "02:15", "02:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "269", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("bd", "02:19", "02:19"),
                       new DepartureEntity("ddr", "02:40", "02:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "270", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("bkl", "09:28", "09:28"),
                       new DepartureEntity("mas", "09:33", "09:33"),
                       new DepartureEntity("ut", "09:41", "09:43"),
                       new DepartureEntity("bnk", "09:49", "09:49"),
                       new DepartureEntity("db", "09:53", "09:53"),
                       new DepartureEntity("mrn", "09:59", "09:59"),
                       new DepartureEntity("vndw", "10:09", "10:09"),
                       new DepartureEntity("vndc", "10:12", "10:15"),
                       new DepartureEntity("rhn", "10:21", "10:21"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "271", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("bkl", "18:28", "18:28"),
                       new DepartureEntity("mas", "18:33", "18:33"),
                       new DepartureEntity("ut", "18:41", "18:43"),
                       new DepartureEntity("bnk", "18:49", "18:49"),
                       new DepartureEntity("db", "18:53", "18:53"),
                       new DepartureEntity("mrn", "18:59", "18:59"),
                       new DepartureEntity("vndw", "19:09", "19:09"),
                       new DepartureEntity("vndc", "19:12", "19:15"),
                       new DepartureEntity("rhn", "19:21", "19:21"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "272", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "07:43", "07:43"),
                       new DepartureEntity("bnk", "07:49", "07:49"),
                       new DepartureEntity("db", "07:53", "07:53"),
                       new DepartureEntity("mrn", "07:59", "07:59"),
                       new DepartureEntity("vndw", "08:09", "08:09"),
                       new DepartureEntity("vndc", "08:12", "08:15"),
                       new DepartureEntity("rhn", "08:21", "08:21"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "273", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("bkl", "07:28", "07:28"),
                       new DepartureEntity("mas", "07:33", "07:33"),
                       new DepartureEntity("ut", "07:41", "07:43"),
                       new DepartureEntity("bnk", "07:49", "07:49"),
                       new DepartureEntity("db", "07:53", "07:53"),
                       new DepartureEntity("mrn", "07:59", "07:59"),
                       new DepartureEntity("vndw", "08:09", "08:09"),
                       new DepartureEntity("vndc", "08:12", "08:15"),
                       new DepartureEntity("rhn", "08:21", "08:21"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "274", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "07:43", "07:43"),
                       new DepartureEntity("bnk", "07:49", "07:49"),
                       new DepartureEntity("db", "07:53", "07:53"),
                       new DepartureEntity("mrn", "07:59", "07:59"),
                       new DepartureEntity("vndw", "08:09", "08:09"),
                       new DepartureEntity("vndc", "08:12", "08:15"),
                       new DepartureEntity("rhn", "08:21", "08:21"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "275", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("bkl", "16:28", "16:28"),
                       new DepartureEntity("mas", "16:33", "16:33"),
                       new DepartureEntity("ut", "16:41", "16:43"),
                       new DepartureEntity("bnk", "16:49", "16:49"),
                       new DepartureEntity("db", "16:54", "16:54"),
                       new DepartureEntity("mrn", "17:00", "17:00"),
                       new DepartureEntity("vndw", "17:09", "17:09"),
                       new DepartureEntity("vndc", "17:12", "17:15"),
                       new DepartureEntity("rhn", "17:21", "17:21"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "276", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("bkl", "16:28", "16:28"),
                       new DepartureEntity("mas", "16:33", "16:33"),
                       new DepartureEntity("ut", "16:41", "16:43"),
                       new DepartureEntity("bnk", "16:49", "16:49"),
                       new DepartureEntity("db", "16:53", "16:53"),
                       new DepartureEntity("mrn", "16:59", "16:59"),
                       new DepartureEntity("vndw", "17:09", "17:09"),
                       new DepartureEntity("vndc", "17:12", "17:15"),
                       new DepartureEntity("rhn", "17:21", "17:21"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "277", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("bkl", "16:58", "16:58"),
                       new DepartureEntity("mas", "17:03", "17:03"),
                       new DepartureEntity("ut", "17:11", "17:13"),
                       new DepartureEntity("bnk", "17:19", "17:19"),
                       new DepartureEntity("db", "17:23", "17:23"),
                       new DepartureEntity("mrn", "17:29", "17:29"),
                       new DepartureEntity("vndw", "17:39", "17:39"),
                       new DepartureEntity("vndc", "17:42", "17:45"),
                       new DepartureEntity("rhn", "17:51", "17:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "278", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("bkl", "17:28", "17:28"),
                       new DepartureEntity("mas", "17:33", "17:33"),
                       new DepartureEntity("ut", "17:41", "17:43"),
                       new DepartureEntity("bnk", "17:49", "17:49"),
                       new DepartureEntity("db", "17:53", "17:53"),
                       new DepartureEntity("mrn", "17:59", "17:59"),
                       new DepartureEntity("vndw", "18:09", "18:09"),
                       new DepartureEntity("vndc", "18:12", "18:15"),
                       new DepartureEntity("rhn", "18:21", "18:21"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "279", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("bkl", "18:58", "18:58"),
                       new DepartureEntity("mas", "19:03", "19:03"),
                       new DepartureEntity("ut", "19:11", "19:13"),
                       new DepartureEntity("bnk", "19:19", "19:19"),
                       new DepartureEntity("db", "19:23", "19:23"),
                       new DepartureEntity("mrn", "19:29", "19:29"),
                       new DepartureEntity("vndw", "19:39", "19:39"),
                       new DepartureEntity("vndc", "19:42", "19:45"),
                       new DepartureEntity("rhn", "19:51", "19:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "280", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("bkl", "18:58", "18:58"),
                       new DepartureEntity("mas", "19:03", "19:03"),
                       new DepartureEntity("ut", "19:11", "19:13"),
                       new DepartureEntity("bnk", "19:19", "19:19"),
                       new DepartureEntity("db", "19:23", "19:23"),
                       new DepartureEntity("mrn", "19:29", "19:29"),
                       new DepartureEntity("vndw", "19:39", "19:39"),
                       new DepartureEntity("vndc", "19:42", "19:45"),
                       new DepartureEntity("rhn", "19:51", "19:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "281", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("bkl", "08:28", "08:28"),
                       new DepartureEntity("mas", "08:33", "08:33"),
                       new DepartureEntity("ut", "08:41", "08:43"),
                       new DepartureEntity("bnk", "08:49", "08:49"),
                       new DepartureEntity("db", "08:54", "08:54"),
                       new DepartureEntity("mrn", "09:00", "09:00"),
                       new DepartureEntity("vndw", "09:09", "09:09"),
                       new DepartureEntity("vndc", "09:12", "09:15"),
                       new DepartureEntity("rhn", "09:21", "09:21"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "282", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("bkl", "08:28", "08:28"),
                       new DepartureEntity("mas", "08:33", "08:33"),
                       new DepartureEntity("ut", "08:41", "08:43"),
                       new DepartureEntity("bnk", "08:49", "08:49"),
                       new DepartureEntity("db", "08:53", "08:53"),
                       new DepartureEntity("mrn", "08:59", "08:59"),
                       new DepartureEntity("vndw", "09:09", "09:09"),
                       new DepartureEntity("vndc", "09:12", "09:15"),
                       new DepartureEntity("rhn", "09:21", "09:21"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "283", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("bkl", "08:58", "08:58"),
                       new DepartureEntity("mas", "09:03", "09:03"),
                       new DepartureEntity("ut", "09:11", "09:14"),
                       new DepartureEntity("bnk", "09:19", "09:19"),
                       new DepartureEntity("db", "09:24", "09:24"),
                       new DepartureEntity("mrn", "09:30", "09:30"),
                       new DepartureEntity("vndw", "09:39", "09:39"),
                       new DepartureEntity("vndc", "09:42", "09:45"),
                       new DepartureEntity("rhn", "09:51", "09:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "284", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("bkl", "08:58", "08:58"),
                       new DepartureEntity("mas", "09:03", "09:03"),
                       new DepartureEntity("ut", "09:11", "09:13"),
                       new DepartureEntity("bnk", "09:19", "09:19"),
                       new DepartureEntity("db", "09:23", "09:23"),
                       new DepartureEntity("mrn", "09:29", "09:29"),
                       new DepartureEntity("vndw", "09:39", "09:39"),
                       new DepartureEntity("vndc", "09:42", "09:45"),
                       new DepartureEntity("rhn", "09:51", "09:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "285", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("bkl", "17:58", "17:58"),
                       new DepartureEntity("mas", "18:03", "18:03"),
                       new DepartureEntity("ut", "18:11", "18:14"),
                       new DepartureEntity("bnk", "18:20", "18:20"),
                       new DepartureEntity("db", "18:24", "18:24"),
                       new DepartureEntity("mrn", "18:30", "18:30"),
                       new DepartureEntity("vndw", "18:39", "18:39"),
                       new DepartureEntity("vndc", "18:42", "18:45"),
                       new DepartureEntity("rhn", "18:51", "18:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "286", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("bkl", "17:58", "17:58"),
                       new DepartureEntity("mas", "18:03", "18:03"),
                       new DepartureEntity("ut", "18:11", "18:14"),
                       new DepartureEntity("bnk", "18:20", "18:20"),
                       new DepartureEntity("db", "18:24", "18:24"),
                       new DepartureEntity("mrn", "18:30", "18:30"),
                       new DepartureEntity("vndw", "18:39", "18:39"),
                       new DepartureEntity("vndc", "18:42", "18:45"),
                       new DepartureEntity("rhn", "18:51", "18:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "287", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("bkl", "07:58", "07:58"),
                       new DepartureEntity("mas", "08:03", "08:03"),
                       new DepartureEntity("ut", "08:11", "08:14"),
                       new DepartureEntity("bnk", "08:19", "08:19"),
                       new DepartureEntity("db", "08:24", "08:24"),
                       new DepartureEntity("mrn", "08:30", "08:30"),
                       new DepartureEntity("vndw", "08:39", "08:39"),
                       new DepartureEntity("vndc", "08:42", "08:45"),
                       new DepartureEntity("rhn", "08:51", "08:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "288", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "07:10", "07:10"),
                       new DepartureEntity("ut", "07:24", "07:29"),
                       new DepartureEntity("gd", "07:47", "07:52"),
                       new DepartureEntity("rta", "08:01", "08:01"),
                       new DepartureEntity("rtd", "08:10", "08:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "289", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "07:10", "07:10"),
                       new DepartureEntity("ut", "07:24", "07:29"),
                       new DepartureEntity("gd", "07:47", "07:52"),
                       new DepartureEntity("rta", "08:01", "08:01"),
                       new DepartureEntity("rtd", "08:10", "08:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "290", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "07:10", "07:10"),
                       new DepartureEntity("ut", "07:24", "07:29"),
                       new DepartureEntity("gd", "07:47", "07:52"),
                       new DepartureEntity("rta", "08:01", "08:01"),
                       new DepartureEntity("rtd", "08:10", "08:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "291", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "05:46", "05:46"),
                       new DepartureEntity("hgl", "05:53", "05:54"),
                       new DepartureEntity("aml", "06:05", "06:06"),
                       new DepartureEntity("dv", "06:29", "06:32"),
                       new DepartureEntity("apd", "06:42", "06:43"),
                       new DepartureEntity("amf", "07:07", "07:10"),
                       new DepartureEntity("ut", "07:24", "07:32"),
                       new DepartureEntity("gd", "07:51", "07:52"),
                       new DepartureEntity("rta", "08:01", "08:01"),
                       new DepartureEntity("rtd", "08:10", "08:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "292", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "05:46", "05:46"),
                       new DepartureEntity("hgl", "05:53", "05:54"),
                       new DepartureEntity("aml", "06:05", "06:06"),
                       new DepartureEntity("dv", "06:29", "06:32"),
                       new DepartureEntity("apd", "06:42", "06:43"),
                       new DepartureEntity("amf", "07:07", "07:10"),
                       new DepartureEntity("ut", "07:24", "07:29"),
                       new DepartureEntity("gd", "07:48", "07:49"),
                       new DepartureEntity("gvc", "08:07", "08:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "293", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "06:32", "06:32"),
                       new DepartureEntity("apd", "06:42", "06:43"),
                       new DepartureEntity("amf", "07:07", "07:10"),
                       new DepartureEntity("ut", "07:26", "07:26"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "294", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "07:10", "07:10"),
                       new DepartureEntity("ut", "07:24", "07:29"),
                       new DepartureEntity("gd", "07:47", "07:49"),
                       new DepartureEntity("gvc", "08:07", "08:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "295", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "06:32", "06:32"),
                       new DepartureEntity("apd", "06:42", "06:43"),
                       new DepartureEntity("amf", "07:07", "07:10"),
                       new DepartureEntity("ut", "07:24", "07:29"),
                       new DepartureEntity("gd", "07:47", "07:49"),
                       new DepartureEntity("gvc", "08:07", "08:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "296", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "05:46", "05:46"),
                       new DepartureEntity("hgl", "05:53", "05:54"),
                       new DepartureEntity("aml", "06:05", "06:06"),
                       new DepartureEntity("dv", "06:29", "06:32"),
                       new DepartureEntity("apd", "06:42", "06:43"),
                       new DepartureEntity("amf", "07:07", "07:10"),
                       new DepartureEntity("ut", "07:24", "07:29"),
                       new DepartureEntity("gd", "07:48", "07:49"),
                       new DepartureEntity("gvc", "08:07", "08:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "297", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "06:32", "06:32"),
                       new DepartureEntity("apd", "06:42", "06:43"),
                       new DepartureEntity("amf", "07:07", "07:10"),
                       new DepartureEntity("ut", "07:24", "07:29"),
                       new DepartureEntity("gd", "07:49", "07:50"),
                       new DepartureEntity("gvc", "08:11", "08:11"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "298", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "08:20", "08:20"),
                       new DepartureEntity("rta", "08:28", "08:28"),
                       new DepartureEntity("gd", "08:38", "08:39"),
                       new DepartureEntity("ut", "08:58", "09:06"),
                       new DepartureEntity("amf", "09:20", "09:25"),
                       new DepartureEntity("amfs", "09:29", "09:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "299", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "08:20", "08:20"),
                       new DepartureEntity("rta", "08:28", "08:28"),
                       new DepartureEntity("gd", "08:38", "08:43"),
                       new DepartureEntity("ut", "09:01", "09:06"),
                       new DepartureEntity("amf", "09:20", "09:25"),
                       new DepartureEntity("amfs", "09:29", "09:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "300", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "09:06", "09:06"),
                       new DepartureEntity("amf", "09:20", "09:20"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "301", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "08:20", "08:20"),
                       new DepartureEntity("gd", "08:37", "08:43"),
                       new DepartureEntity("ut", "09:01", "09:06"),
                       new DepartureEntity("amf", "09:20", "09:25"),
                       new DepartureEntity("amfs", "09:29", "09:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "302", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "08:20", "08:20"),
                       new DepartureEntity("gd", "08:37", "08:43"),
                       new DepartureEntity("ut", "09:01", "09:06"),
                       new DepartureEntity("amf", "09:20", "09:25"),
                       new DepartureEntity("amfs", "09:29", "09:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "303", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "08:23", "08:23"),
                       new DepartureEntity("gd", "08:40", "08:43"),
                       new DepartureEntity("ut", "09:01", "09:06"),
                       new DepartureEntity("amf", "09:20", "09:25"),
                       new DepartureEntity("amfs", "09:29", "09:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "304", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "08:24", "08:24"),
                       new DepartureEntity("gd", "08:41", "08:42"),
                       new DepartureEntity("ut", "09:01", "09:06"),
                       new DepartureEntity("amf", "09:20", "09:25"),
                       new DepartureEntity("amfs", "09:29", "09:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "305", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "08:23", "08:23"),
                       new DepartureEntity("gd", "08:40", "08:43"),
                       new DepartureEntity("ut", "09:01", "09:06"),
                       new DepartureEntity("amf", "09:20", "09:25"),
                       new DepartureEntity("amfs", "09:29", "09:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "306", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "09:34", "09:34"),
                       new DepartureEntity("amf", "09:38", "09:40"),
                       new DepartureEntity("ut", "09:54", "09:59"),
                       new DepartureEntity("gd", "10:17", "10:22"),
                       new DepartureEntity("rta", "10:31", "10:31"),
                       new DepartureEntity("rtd", "10:40", "10:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "307", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "09:34", "09:34"),
                       new DepartureEntity("amf", "09:38", "09:40"),
                       new DepartureEntity("ut", "09:54", "09:59"),
                       new DepartureEntity("gd", "10:17", "10:22"),
                       new DepartureEntity("rta", "10:31", "10:31"),
                       new DepartureEntity("rtd", "10:40", "10:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "308", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "09:34", "09:34"),
                       new DepartureEntity("amf", "09:38", "09:40"),
                       new DepartureEntity("ut", "09:54", "10:02"),
                       new DepartureEntity("gd", "10:21", "10:22"),
                       new DepartureEntity("rta", "10:31", "10:31"),
                       new DepartureEntity("rtd", "10:40", "10:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "309", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "09:40", "09:40"),
                       new DepartureEntity("ut", "09:56", "09:56"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "310", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "09:34", "09:34"),
                       new DepartureEntity("amf", "09:38", "09:40"),
                       new DepartureEntity("ut", "09:54", "09:59"),
                       new DepartureEntity("gd", "10:19", "10:20"),
                       new DepartureEntity("gvc", "10:41", "10:41"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "311", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "09:34", "09:34"),
                       new DepartureEntity("amf", "09:38", "09:40"),
                       new DepartureEntity("ut", "09:54", "09:59"),
                       new DepartureEntity("gd", "10:18", "10:19"),
                       new DepartureEntity("gvc", "10:37", "10:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "312", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "09:34", "09:34"),
                       new DepartureEntity("amf", "09:38", "09:40"),
                       new DepartureEntity("ut", "09:54", "09:59"),
                       new DepartureEntity("gd", "10:17", "10:19"),
                       new DepartureEntity("gvc", "10:37", "10:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "313", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "09:40", "09:40"),
                       new DepartureEntity("ut", "09:56", "09:56"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "314", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "09:34", "09:34"),
                       new DepartureEntity("amf", "09:38", "09:40"),
                       new DepartureEntity("ut", "09:54", "09:59"),
                       new DepartureEntity("gd", "10:17", "10:19"),
                       new DepartureEntity("gvc", "10:37", "10:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "315", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "09:34", "09:34"),
                       new DepartureEntity("amf", "09:38", "09:40"),
                       new DepartureEntity("ut", "09:54", "09:59"),
                       new DepartureEntity("gd", "10:18", "10:19"),
                       new DepartureEntity("gvc", "10:37", "10:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "316", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "09:34", "09:34"),
                       new DepartureEntity("amf", "09:38", "09:40"),
                       new DepartureEntity("ut", "09:54", "09:59"),
                       new DepartureEntity("gd", "10:19", "10:20"),
                       new DepartureEntity("gvc", "10:41", "10:41"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "317", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "09:34", "09:34"),
                       new DepartureEntity("amf", "09:38", "09:40"),
                       new DepartureEntity("ut", "09:54", "09:59"),
                       new DepartureEntity("gd", "10:17", "10:19"),
                       new DepartureEntity("gvc", "10:37", "10:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "318", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "09:34", "09:34"),
                       new DepartureEntity("amf", "09:38", "09:40"),
                       new DepartureEntity("ut", "09:54", "09:59"),
                       new DepartureEntity("gd", "10:17", "10:19"),
                       new DepartureEntity("gvc", "10:40", "10:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "319", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "10:50", "10:50"),
                       new DepartureEntity("rta", "10:58", "10:58"),
                       new DepartureEntity("gd", "11:08", "11:09"),
                       new DepartureEntity("ut", "11:28", "11:36"),
                       new DepartureEntity("amf", "11:50", "11:53"),
                       new DepartureEntity("apd", "12:17", "12:18"),
                       new DepartureEntity("dv", "12:28", "12:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "320", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "10:50", "10:50"),
                       new DepartureEntity("rta", "10:58", "10:58"),
                       new DepartureEntity("gd", "11:08", "11:13"),
                       new DepartureEntity("ut", "11:31", "11:36"),
                       new DepartureEntity("amf", "11:50", "11:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "321", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "10:50", "10:50"),
                       new DepartureEntity("rta", "10:58", "10:58"),
                       new DepartureEntity("gd", "11:08", "11:13"),
                       new DepartureEntity("ut", "11:31", "11:36"),
                       new DepartureEntity("amf", "11:50", "11:53"),
                       new DepartureEntity("apd", "12:17", "12:18"),
                       new DepartureEntity("dv", "12:28", "12:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "322", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "11:36", "11:36"),
                       new DepartureEntity("amf", "11:50", "11:53"),
                       new DepartureEntity("apd", "12:17", "12:18"),
                       new DepartureEntity("dv", "12:28", "12:30"),
                       new DepartureEntity("aml", "12:55", "12:56"),
                       new DepartureEntity("hgl", "13:07", "13:08"),
                       new DepartureEntity("es", "13:15", "13:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "323", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "10:53", "10:53"),
                       new DepartureEntity("gd", "11:13", "11:14"),
                       new DepartureEntity("ut", "11:32", "11:37"),
                       new DepartureEntity("amf", "11:50", "11:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "324", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "10:53", "10:53"),
                       new DepartureEntity("gd", "11:10", "11:13"),
                       new DepartureEntity("ut", "11:31", "11:36"),
                       new DepartureEntity("amf", "11:50", "11:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "325", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "10:50", "10:50"),
                       new DepartureEntity("gd", "11:07", "11:13"),
                       new DepartureEntity("ut", "11:31", "11:36"),
                       new DepartureEntity("amf", "11:50", "11:53"),
                       new DepartureEntity("apd", "12:17", "12:18"),
                       new DepartureEntity("dv", "12:28", "12:30"),
                       new DepartureEntity("aml", "12:55", "12:56"),
                       new DepartureEntity("hgl", "13:07", "13:08"),
                       new DepartureEntity("es", "13:15", "13:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "326", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "10:53", "10:53"),
                       new DepartureEntity("gd", "11:10", "11:13"),
                       new DepartureEntity("ut", "11:31", "11:36"),
                       new DepartureEntity("amf", "11:50", "11:53"),
                       new DepartureEntity("apd", "12:17", "12:18"),
                       new DepartureEntity("dv", "12:28", "12:30"),
                       new DepartureEntity("aml", "12:55", "12:56"),
                       new DepartureEntity("hgl", "13:07", "13:08"),
                       new DepartureEntity("es", "13:15", "13:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "327", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "10:54", "10:54"),
                       new DepartureEntity("gd", "11:11", "11:12"),
                       new DepartureEntity("ut", "11:31", "11:36"),
                       new DepartureEntity("amf", "11:50", "11:53"),
                       new DepartureEntity("apd", "12:17", "12:18"),
                       new DepartureEntity("dv", "12:28", "12:30"),
                       new DepartureEntity("aml", "12:55", "12:56"),
                       new DepartureEntity("hgl", "13:07", "13:08"),
                       new DepartureEntity("es", "13:15", "13:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "328", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "10:53", "10:53"),
                       new DepartureEntity("gd", "11:10", "11:13"),
                       new DepartureEntity("ut", "11:31", "11:36"),
                       new DepartureEntity("amf", "11:50", "11:53"),
                       new DepartureEntity("apd", "12:17", "12:18"),
                       new DepartureEntity("dv", "12:28", "12:30"),
                       new DepartureEntity("aml", "12:55", "12:56"),
                       new DepartureEntity("hgl", "13:07", "13:08"),
                       new DepartureEntity("es", "13:15", "13:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "329", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "10:50", "10:50"),
                       new DepartureEntity("gd", "11:07", "11:13"),
                       new DepartureEntity("ut", "11:31", "11:36"),
                       new DepartureEntity("amf", "11:50", "11:53"),
                       new DepartureEntity("apd", "12:17", "12:18"),
                       new DepartureEntity("dv", "12:28", "12:30"),
                       new DepartureEntity("aml", "12:55", "12:56"),
                       new DepartureEntity("hgl", "13:07", "13:08"),
                       new DepartureEntity("es", "13:15", "13:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "330", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "11:36", "11:36"),
                       new DepartureEntity("amf", "11:50", "11:53"),
                       new DepartureEntity("apd", "12:17", "12:18"),
                       new DepartureEntity("dv", "12:28", "12:30"),
                       new DepartureEntity("aml", "12:55", "12:56"),
                       new DepartureEntity("hgl", "13:07", "13:08"),
                       new DepartureEntity("es", "13:15", "13:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "331", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "14:10", "14:10"),
                       new DepartureEntity("ut", "14:24", "14:29"),
                       new DepartureEntity("gd", "14:47", "14:52"),
                       new DepartureEntity("rta", "15:01", "15:01"),
                       new DepartureEntity("rtd", "15:10", "15:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "332", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "14:10", "14:10"),
                       new DepartureEntity("ut", "14:24", "14:29"),
                       new DepartureEntity("gd", "14:47", "14:52"),
                       new DepartureEntity("rta", "15:01", "15:01"),
                       new DepartureEntity("rtd", "15:10", "15:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "333", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "13:32", "13:32"),
                       new DepartureEntity("apd", "13:42", "13:43"),
                       new DepartureEntity("amf", "14:07", "14:10"),
                       new DepartureEntity("ut", "14:24", "14:29"),
                       new DepartureEntity("gd", "14:47", "14:52"),
                       new DepartureEntity("rta", "15:01", "15:01"),
                       new DepartureEntity("rtd", "15:10", "15:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "334", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "13:32", "13:32"),
                       new DepartureEntity("apd", "13:42", "13:43"),
                       new DepartureEntity("amf", "14:07", "14:10"),
                       new DepartureEntity("ut", "14:24", "14:29"),
                       new DepartureEntity("gd", "14:47", "14:52"),
                       new DepartureEntity("rta", "15:01", "15:01"),
                       new DepartureEntity("rtd", "15:10", "15:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "335", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "13:32", "13:32"),
                       new DepartureEntity("apd", "13:42", "13:43"),
                       new DepartureEntity("amf", "14:07", "14:10"),
                       new DepartureEntity("ut", "14:24", "14:29"),
                       new DepartureEntity("gd", "14:47", "14:52"),
                       new DepartureEntity("rta", "15:01", "15:01"),
                       new DepartureEntity("rtd", "15:10", "15:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "336", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "13:32", "13:32"),
                       new DepartureEntity("apd", "13:42", "13:43"),
                       new DepartureEntity("amf", "14:07", "14:10"),
                       new DepartureEntity("ut", "14:24", "14:32"),
                       new DepartureEntity("gd", "14:51", "14:52"),
                       new DepartureEntity("rta", "15:01", "15:01"),
                       new DepartureEntity("rtd", "15:10", "15:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "337", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "14:10", "14:10"),
                       new DepartureEntity("ut", "14:24", "14:29"),
                       new DepartureEntity("gd", "14:47", "14:49"),
                       new DepartureEntity("gvc", "15:07", "15:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "338", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "12:46", "12:46"),
                       new DepartureEntity("hgl", "12:53", "12:54"),
                       new DepartureEntity("aml", "13:05", "13:06"),
                       new DepartureEntity("dv", "13:29", "13:32"),
                       new DepartureEntity("apd", "13:42", "13:43"),
                       new DepartureEntity("amf", "14:07", "14:10"),
                       new DepartureEntity("ut", "14:24", "14:29"),
                       new DepartureEntity("gd", "14:47", "14:49"),
                       new DepartureEntity("gvc", "15:07", "15:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "339", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "12:46", "12:46"),
                       new DepartureEntity("hgl", "12:53", "12:54"),
                       new DepartureEntity("aml", "13:05", "13:06"),
                       new DepartureEntity("dv", "13:29", "13:32"),
                       new DepartureEntity("apd", "13:42", "13:43"),
                       new DepartureEntity("amf", "14:07", "14:10"),
                       new DepartureEntity("ut", "14:24", "14:29"),
                       new DepartureEntity("gd", "14:47", "14:49"),
                       new DepartureEntity("gvc", "15:07", "15:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "340", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "12:46", "12:46"),
                       new DepartureEntity("hgl", "12:53", "12:54"),
                       new DepartureEntity("aml", "13:05", "13:06"),
                       new DepartureEntity("dv", "13:29", "13:32"),
                       new DepartureEntity("apd", "13:42", "13:43"),
                       new DepartureEntity("amf", "14:07", "14:10"),
                       new DepartureEntity("ut", "14:24", "14:29"),
                       new DepartureEntity("gd", "14:49", "14:50"),
                       new DepartureEntity("gvc", "15:11", "15:11"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "341", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "12:46", "12:46"),
                       new DepartureEntity("hgl", "12:53", "12:54"),
                       new DepartureEntity("aml", "13:05", "13:06"),
                       new DepartureEntity("dv", "13:29", "13:32"),
                       new DepartureEntity("apd", "13:42", "13:43"),
                       new DepartureEntity("amf", "14:07", "14:10"),
                       new DepartureEntity("ut", "14:26", "14:26"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "342", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "12:46", "12:46"),
                       new DepartureEntity("hgl", "12:53", "12:54"),
                       new DepartureEntity("aml", "13:05", "13:06"),
                       new DepartureEntity("dv", "13:29", "13:32"),
                       new DepartureEntity("apd", "13:42", "13:43"),
                       new DepartureEntity("amf", "14:07", "14:10"),
                       new DepartureEntity("ut", "14:26", "14:26"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "343", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "12:46", "12:46"),
                       new DepartureEntity("hgl", "12:53", "12:54"),
                       new DepartureEntity("aml", "13:05", "13:06"),
                       new DepartureEntity("dv", "13:29", "13:32"),
                       new DepartureEntity("apd", "13:42", "13:43"),
                       new DepartureEntity("amf", "14:07", "14:10"),
                       new DepartureEntity("ut", "14:24", "14:29"),
                       new DepartureEntity("gd", "14:48", "14:49"),
                       new DepartureEntity("gvc", "15:07", "15:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "344", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "14:10", "14:10"),
                       new DepartureEntity("ut", "14:24", "14:29"),
                       new DepartureEntity("gd", "14:47", "14:49"),
                       new DepartureEntity("gvc", "15:07", "15:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "345", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "12:46", "12:46"),
                       new DepartureEntity("hgl", "12:53", "12:54"),
                       new DepartureEntity("aml", "13:05", "13:06"),
                       new DepartureEntity("dv", "13:29", "13:32"),
                       new DepartureEntity("apd", "13:42", "13:43"),
                       new DepartureEntity("amf", "14:07", "14:10"),
                       new DepartureEntity("ut", "14:24", "14:29"),
                       new DepartureEntity("gd", "14:48", "14:49"),
                       new DepartureEntity("gvc", "15:07", "15:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "346", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "12:46", "12:46"),
                       new DepartureEntity("hgl", "12:53", "12:54"),
                       new DepartureEntity("aml", "13:05", "13:06"),
                       new DepartureEntity("dv", "13:29", "13:32"),
                       new DepartureEntity("apd", "13:42", "13:43"),
                       new DepartureEntity("amf", "14:07", "14:10"),
                       new DepartureEntity("ut", "14:24", "14:29"),
                       new DepartureEntity("gd", "14:49", "14:50"),
                       new DepartureEntity("gvc", "15:11", "15:11"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "347", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "15:20", "15:20"),
                       new DepartureEntity("rta", "15:28", "15:28"),
                       new DepartureEntity("gd", "15:38", "15:39"),
                       new DepartureEntity("ut", "15:58", "16:06"),
                       new DepartureEntity("amf", "16:20", "16:25"),
                       new DepartureEntity("amfs", "16:29", "16:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "348", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "15:20", "15:20"),
                       new DepartureEntity("rta", "15:28", "15:28"),
                       new DepartureEntity("gd", "15:38", "15:43"),
                       new DepartureEntity("ut", "16:01", "16:06"),
                       new DepartureEntity("amf", "16:20", "16:25"),
                       new DepartureEntity("amfs", "16:29", "16:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "349", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "15:20", "15:20"),
                       new DepartureEntity("rta", "15:28", "15:28"),
                       new DepartureEntity("gd", "15:38", "15:43"),
                       new DepartureEntity("ut", "16:01", "16:06"),
                       new DepartureEntity("amf", "16:20", "16:25"),
                       new DepartureEntity("amfs", "16:29", "16:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "350", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "16:06", "16:06"),
                       new DepartureEntity("amf", "16:20", "16:20"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "351", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "15:20", "15:20"),
                       new DepartureEntity("gd", "15:37", "15:43"),
                       new DepartureEntity("ut", "16:01", "16:06"),
                       new DepartureEntity("amf", "16:20", "16:25"),
                       new DepartureEntity("amfs", "16:29", "16:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "352", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "15:23", "15:23"),
                       new DepartureEntity("gd", "15:40", "15:43"),
                       new DepartureEntity("ut", "16:01", "16:06"),
                       new DepartureEntity("amf", "16:20", "16:25"),
                       new DepartureEntity("amfs", "16:29", "16:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "353", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "15:24", "15:24"),
                       new DepartureEntity("gd", "15:41", "15:42"),
                       new DepartureEntity("ut", "16:01", "16:06"),
                       new DepartureEntity("amf", "16:20", "16:25"),
                       new DepartureEntity("amfs", "16:29", "16:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "354", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "15:23", "15:23"),
                       new DepartureEntity("gd", "15:40", "15:43"),
                       new DepartureEntity("ut", "16:01", "16:06"),
                       new DepartureEntity("amf", "16:20", "16:25"),
                       new DepartureEntity("amfs", "16:29", "16:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "355", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "16:06", "16:06"),
                       new DepartureEntity("amf", "16:20", "16:20"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "356", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "16:34", "16:34"),
                       new DepartureEntity("amf", "16:38", "16:40"),
                       new DepartureEntity("ut", "16:54", "16:59"),
                       new DepartureEntity("gd", "17:17", "17:22"),
                       new DepartureEntity("rta", "17:31", "17:31"),
                       new DepartureEntity("rtd", "17:40", "17:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "357", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "16:34", "16:34"),
                       new DepartureEntity("amf", "16:38", "16:40"),
                       new DepartureEntity("ut", "16:54", "16:59"),
                       new DepartureEntity("gd", "17:17", "17:22"),
                       new DepartureEntity("rta", "17:31", "17:31"),
                       new DepartureEntity("rtd", "17:40", "17:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "358", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "16:34", "16:34"),
                       new DepartureEntity("amf", "16:38", "16:40"),
                       new DepartureEntity("ut", "16:54", "16:59"),
                       new DepartureEntity("gd", "17:17", "17:22"),
                       new DepartureEntity("rta", "17:31", "17:31"),
                       new DepartureEntity("rtd", "17:40", "17:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "359", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "16:34", "16:34"),
                       new DepartureEntity("amf", "16:38", "16:40"),
                       new DepartureEntity("ut", "16:54", "16:59"),
                       new DepartureEntity("gd", "17:17", "17:22"),
                       new DepartureEntity("rta", "17:31", "17:31"),
                       new DepartureEntity("rtd", "17:40", "17:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "360", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "16:34", "16:34"),
                       new DepartureEntity("amf", "16:38", "16:40"),
                       new DepartureEntity("ut", "16:54", "17:02"),
                       new DepartureEntity("gd", "17:21", "17:22"),
                       new DepartureEntity("rta", "17:31", "17:31"),
                       new DepartureEntity("rtd", "17:40", "17:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "361", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "16:40", "16:40"),
                       new DepartureEntity("ut", "16:56", "16:56"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "362", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "16:34", "16:34"),
                       new DepartureEntity("amf", "16:38", "16:40"),
                       new DepartureEntity("ut", "16:54", "16:59"),
                       new DepartureEntity("gd", "17:17", "17:19"),
                       new DepartureEntity("gvc", "17:37", "17:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "363", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "16:34", "16:34"),
                       new DepartureEntity("amf", "16:38", "16:40"),
                       new DepartureEntity("ut", "16:54", "16:59"),
                       new DepartureEntity("gd", "17:18", "17:19"),
                       new DepartureEntity("gvc", "17:37", "17:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "364", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "16:34", "16:34"),
                       new DepartureEntity("amf", "16:38", "16:40"),
                       new DepartureEntity("ut", "16:54", "16:59"),
                       new DepartureEntity("gd", "17:17", "17:19"),
                       new DepartureEntity("gvc", "17:37", "17:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "365", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "16:34", "16:34"),
                       new DepartureEntity("amf", "16:38", "16:40"),
                       new DepartureEntity("ut", "16:54", "16:59"),
                       new DepartureEntity("gd", "17:18", "17:19"),
                       new DepartureEntity("gvc", "17:37", "17:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "366", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "16:34", "16:34"),
                       new DepartureEntity("amf", "16:38", "16:40"),
                       new DepartureEntity("ut", "16:54", "16:59"),
                       new DepartureEntity("gd", "17:19", "17:20"),
                       new DepartureEntity("gvc", "17:41", "17:41"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "367", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "09:10", "09:10"),
                       new DepartureEntity("ut", "09:24", "09:29"),
                       new DepartureEntity("gd", "09:47", "09:52"),
                       new DepartureEntity("rta", "10:01", "10:01"),
                       new DepartureEntity("rtd", "10:10", "10:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "368", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "07:46", "07:46"),
                       new DepartureEntity("hgl", "07:53", "07:54"),
                       new DepartureEntity("aml", "08:05", "08:06"),
                       new DepartureEntity("dv", "08:29", "08:32"),
                       new DepartureEntity("apd", "08:42", "08:43"),
                       new DepartureEntity("amf", "09:07", "09:10"),
                       new DepartureEntity("ut", "09:24", "09:29"),
                       new DepartureEntity("gd", "09:47", "09:52"),
                       new DepartureEntity("rta", "10:01", "10:01"),
                       new DepartureEntity("rtd", "10:10", "10:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "369", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "07:46", "07:46"),
                       new DepartureEntity("hgl", "07:53", "07:54"),
                       new DepartureEntity("aml", "08:05", "08:06"),
                       new DepartureEntity("dv", "08:29", "08:32"),
                       new DepartureEntity("apd", "08:42", "08:43"),
                       new DepartureEntity("amf", "09:07", "09:10"),
                       new DepartureEntity("ut", "09:24", "09:29"),
                       new DepartureEntity("gd", "09:47", "09:52"),
                       new DepartureEntity("rta", "10:01", "10:01"),
                       new DepartureEntity("rtd", "10:10", "10:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "370", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "08:32", "08:32"),
                       new DepartureEntity("apd", "08:42", "08:43"),
                       new DepartureEntity("amf", "09:07", "09:10"),
                       new DepartureEntity("ut", "09:24", "09:32"),
                       new DepartureEntity("gd", "09:51", "09:52"),
                       new DepartureEntity("rta", "10:01", "10:01"),
                       new DepartureEntity("rtd", "10:10", "10:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "371", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "08:32", "08:32"),
                       new DepartureEntity("apd", "08:42", "08:43"),
                       new DepartureEntity("amf", "09:07", "09:10"),
                       new DepartureEntity("ut", "09:24", "09:32"),
                       new DepartureEntity("gd", "09:51", "09:52"),
                       new DepartureEntity("rta", "10:01", "10:01"),
                       new DepartureEntity("rtd", "10:10", "10:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "372", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "09:10", "09:10"),
                       new DepartureEntity("ut", "09:24", "09:29"),
                       new DepartureEntity("gd", "09:47", "09:49"),
                       new DepartureEntity("gvc", "10:07", "10:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "373", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "07:46", "07:46"),
                       new DepartureEntity("hgl", "07:53", "07:54"),
                       new DepartureEntity("aml", "08:05", "08:06"),
                       new DepartureEntity("dv", "08:29", "08:32"),
                       new DepartureEntity("apd", "08:42", "08:43"),
                       new DepartureEntity("amf", "09:07", "09:10"),
                       new DepartureEntity("ut", "09:26", "09:26"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "374", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "07:46", "07:46"),
                       new DepartureEntity("hgl", "07:53", "07:54"),
                       new DepartureEntity("aml", "08:05", "08:06"),
                       new DepartureEntity("dv", "08:29", "08:32"),
                       new DepartureEntity("apd", "08:42", "08:43"),
                       new DepartureEntity("amf", "09:07", "09:10"),
                       new DepartureEntity("ut", "09:24", "09:29"),
                       new DepartureEntity("gd", "09:47", "09:49"),
                       new DepartureEntity("gvc", "10:07", "10:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "375", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "07:46", "07:46"),
                       new DepartureEntity("hgl", "07:53", "07:54"),
                       new DepartureEntity("aml", "08:05", "08:06"),
                       new DepartureEntity("dv", "08:29", "08:32"),
                       new DepartureEntity("apd", "08:42", "08:43"),
                       new DepartureEntity("amf", "09:07", "09:10"),
                       new DepartureEntity("ut", "09:24", "09:29"),
                       new DepartureEntity("gd", "09:48", "09:49"),
                       new DepartureEntity("gvc", "10:07", "10:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "376", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "07:46", "07:46"),
                       new DepartureEntity("hgl", "07:53", "07:54"),
                       new DepartureEntity("aml", "08:05", "08:06"),
                       new DepartureEntity("dv", "08:29", "08:32"),
                       new DepartureEntity("apd", "08:42", "08:43"),
                       new DepartureEntity("amf", "09:07", "09:10"),
                       new DepartureEntity("ut", "09:26", "09:26"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "377", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "09:10", "09:10"),
                       new DepartureEntity("ut", "09:24", "09:29"),
                       new DepartureEntity("gd", "09:47", "09:49"),
                       new DepartureEntity("gvc", "10:10", "10:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "378", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "07:46", "07:46"),
                       new DepartureEntity("hgl", "07:53", "07:54"),
                       new DepartureEntity("aml", "08:05", "08:06"),
                       new DepartureEntity("dv", "08:29", "08:32"),
                       new DepartureEntity("apd", "08:42", "08:43"),
                       new DepartureEntity("amf", "09:07", "09:10"),
                       new DepartureEntity("ut", "09:24", "09:29"),
                       new DepartureEntity("gd", "09:47", "09:49"),
                       new DepartureEntity("gvc", "10:07", "10:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "379", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "07:46", "07:46"),
                       new DepartureEntity("hgl", "07:53", "07:54"),
                       new DepartureEntity("aml", "08:05", "08:06"),
                       new DepartureEntity("dv", "08:29", "08:32"),
                       new DepartureEntity("apd", "08:42", "08:43"),
                       new DepartureEntity("amf", "09:07", "09:10"),
                       new DepartureEntity("ut", "09:24", "09:29"),
                       new DepartureEntity("gd", "09:48", "09:49"),
                       new DepartureEntity("gvc", "10:07", "10:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "380", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "07:46", "07:46"),
                       new DepartureEntity("hgl", "07:53", "07:54"),
                       new DepartureEntity("aml", "08:05", "08:06"),
                       new DepartureEntity("dv", "08:29", "08:32"),
                       new DepartureEntity("apd", "08:42", "08:43"),
                       new DepartureEntity("amf", "09:07", "09:10"),
                       new DepartureEntity("ut", "09:24", "09:29"),
                       new DepartureEntity("gd", "09:49", "09:50"),
                       new DepartureEntity("gvc", "10:11", "10:11"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "381", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "07:46", "07:46"),
                       new DepartureEntity("hgl", "07:53", "07:54"),
                       new DepartureEntity("aml", "08:05", "08:06"),
                       new DepartureEntity("dv", "08:29", "08:32"),
                       new DepartureEntity("apd", "08:42", "08:43"),
                       new DepartureEntity("amf", "09:07", "09:10"),
                       new DepartureEntity("ut", "09:24", "09:29"),
                       new DepartureEntity("gd", "09:49", "09:50"),
                       new DepartureEntity("gvc", "10:11", "10:11"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "382", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "10:20", "10:20"),
                       new DepartureEntity("rta", "10:28", "10:28"),
                       new DepartureEntity("gd", "10:38", "10:39"),
                       new DepartureEntity("ut", "10:58", "11:06"),
                       new DepartureEntity("amf", "11:20", "11:25"),
                       new DepartureEntity("amfs", "11:29", "11:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "383", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "10:20", "10:20"),
                       new DepartureEntity("rta", "10:28", "10:28"),
                       new DepartureEntity("gd", "10:38", "10:39"),
                       new DepartureEntity("ut", "10:58", "11:06"),
                       new DepartureEntity("amf", "11:20", "11:25"),
                       new DepartureEntity("amfs", "11:29", "11:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "384", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "10:20", "10:20"),
                       new DepartureEntity("rta", "10:28", "10:28"),
                       new DepartureEntity("gd", "10:38", "10:43"),
                       new DepartureEntity("ut", "11:01", "11:06"),
                       new DepartureEntity("amf", "11:20", "11:25"),
                       new DepartureEntity("amfs", "11:29", "11:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "385", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "10:20", "10:20"),
                       new DepartureEntity("rta", "10:28", "10:28"),
                       new DepartureEntity("gd", "10:38", "10:43"),
                       new DepartureEntity("ut", "11:01", "11:06"),
                       new DepartureEntity("amf", "11:20", "11:25"),
                       new DepartureEntity("amfs", "11:29", "11:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "386", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "11:06", "11:06"),
                       new DepartureEntity("amf", "11:20", "11:20"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "387", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "10:23", "10:23"),
                       new DepartureEntity("gd", "10:40", "10:43"),
                       new DepartureEntity("ut", "11:01", "11:06"),
                       new DepartureEntity("amf", "11:20", "11:25"),
                       new DepartureEntity("amfs", "11:29", "11:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "388", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "10:23", "10:23"),
                       new DepartureEntity("gd", "10:40", "10:43"),
                       new DepartureEntity("ut", "11:01", "11:06"),
                       new DepartureEntity("amf", "11:20", "11:25"),
                       new DepartureEntity("amfs", "11:29", "11:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "389", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "10:20", "10:20"),
                       new DepartureEntity("gd", "10:37", "10:43"),
                       new DepartureEntity("ut", "11:01", "11:06"),
                       new DepartureEntity("amf", "11:20", "11:25"),
                       new DepartureEntity("amfs", "11:29", "11:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "390", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "10:20", "10:20"),
                       new DepartureEntity("gd", "10:37", "10:43"),
                       new DepartureEntity("ut", "11:01", "11:06"),
                       new DepartureEntity("amf", "11:20", "11:25"),
                       new DepartureEntity("amfs", "11:29", "11:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "391", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "10:23", "10:23"),
                       new DepartureEntity("gd", "10:40", "10:43"),
                       new DepartureEntity("ut", "11:01", "11:06"),
                       new DepartureEntity("amf", "11:20", "11:25"),
                       new DepartureEntity("amfs", "11:29", "11:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "392", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "10:24", "10:24"),
                       new DepartureEntity("gd", "10:41", "10:42"),
                       new DepartureEntity("ut", "11:01", "11:06"),
                       new DepartureEntity("amf", "11:20", "11:25"),
                       new DepartureEntity("amfs", "11:29", "11:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "393", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "10:23", "10:23"),
                       new DepartureEntity("gd", "10:43", "10:44"),
                       new DepartureEntity("ut", "11:02", "11:07"),
                       new DepartureEntity("amf", "11:20", "11:25"),
                       new DepartureEntity("amfs", "11:29", "11:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "394", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "11:06", "11:06"),
                       new DepartureEntity("amf", "11:20", "11:20"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "395", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "11:34", "11:34"),
                       new DepartureEntity("amf", "11:38", "11:40"),
                       new DepartureEntity("ut", "11:54", "11:59"),
                       new DepartureEntity("gd", "12:17", "12:22"),
                       new DepartureEntity("rta", "12:31", "12:31"),
                       new DepartureEntity("rtd", "12:40", "12:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "396", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "11:34", "11:34"),
                       new DepartureEntity("amf", "11:38", "11:40"),
                       new DepartureEntity("ut", "11:54", "11:59"),
                       new DepartureEntity("gd", "12:17", "12:22"),
                       new DepartureEntity("rta", "12:31", "12:31"),
                       new DepartureEntity("rtd", "12:40", "12:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "397", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "11:34", "11:34"),
                       new DepartureEntity("amf", "11:38", "11:40"),
                       new DepartureEntity("ut", "11:54", "11:59"),
                       new DepartureEntity("gd", "12:17", "12:22"),
                       new DepartureEntity("rta", "12:31", "12:31"),
                       new DepartureEntity("rtd", "12:40", "12:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "398", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "11:34", "11:34"),
                       new DepartureEntity("amf", "11:38", "11:40"),
                       new DepartureEntity("ut", "11:54", "11:59"),
                       new DepartureEntity("gd", "12:17", "12:22"),
                       new DepartureEntity("rta", "12:31", "12:31"),
                       new DepartureEntity("rtd", "12:40", "12:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "399", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "11:34", "11:34"),
                       new DepartureEntity("amf", "11:38", "11:40"),
                       new DepartureEntity("ut", "11:54", "12:02"),
                       new DepartureEntity("gd", "12:21", "12:22"),
                       new DepartureEntity("rta", "12:31", "12:31"),
                       new DepartureEntity("rtd", "12:40", "12:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "400", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "11:40", "11:40"),
                       new DepartureEntity("ut", "11:56", "11:56"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "401", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "11:34", "11:34"),
                       new DepartureEntity("amf", "11:38", "11:40"),
                       new DepartureEntity("ut", "11:54", "11:59"),
                       new DepartureEntity("gd", "12:17", "12:19"),
                       new DepartureEntity("gvc", "12:40", "12:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "402", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "11:34", "11:34"),
                       new DepartureEntity("amf", "11:38", "11:40"),
                       new DepartureEntity("ut", "11:54", "11:59"),
                       new DepartureEntity("gd", "12:17", "12:19"),
                       new DepartureEntity("gvc", "12:37", "12:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "403", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "11:34", "11:34"),
                       new DepartureEntity("amf", "11:38", "11:40"),
                       new DepartureEntity("ut", "11:54", "11:59"),
                       new DepartureEntity("gd", "12:18", "12:19"),
                       new DepartureEntity("gvc", "12:37", "12:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "404", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "11:34", "11:34"),
                       new DepartureEntity("amf", "11:38", "11:40"),
                       new DepartureEntity("ut", "11:54", "11:59"),
                       new DepartureEntity("gd", "12:17", "12:19"),
                       new DepartureEntity("gvc", "12:37", "12:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "405", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "11:40", "11:40"),
                       new DepartureEntity("ut", "11:56", "11:56"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "406", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "11:34", "11:34"),
                       new DepartureEntity("amf", "11:38", "11:40"),
                       new DepartureEntity("ut", "11:54", "11:59"),
                       new DepartureEntity("gd", "12:18", "12:19"),
                       new DepartureEntity("gvc", "12:37", "12:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "407", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "11:34", "11:34"),
                       new DepartureEntity("amf", "11:38", "11:40"),
                       new DepartureEntity("ut", "11:54", "11:59"),
                       new DepartureEntity("gd", "12:19", "12:20"),
                       new DepartureEntity("gvc", "12:41", "12:41"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "408", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "17:20", "17:20"),
                       new DepartureEntity("rta", "17:28", "17:28"),
                       new DepartureEntity("gd", "17:38", "17:39"),
                       new DepartureEntity("ut", "17:58", "18:06"),
                       new DepartureEntity("amf", "18:20", "18:25"),
                       new DepartureEntity("amfs", "18:29", "18:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "409", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "17:20", "17:20"),
                       new DepartureEntity("rta", "17:28", "17:28"),
                       new DepartureEntity("gd", "17:38", "17:43"),
                       new DepartureEntity("ut", "18:01", "18:06"),
                       new DepartureEntity("amf", "18:20", "18:25"),
                       new DepartureEntity("amfs", "18:29", "18:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "410", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "17:20", "17:20"),
                       new DepartureEntity("rta", "17:28", "17:28"),
                       new DepartureEntity("gd", "17:38", "17:43"),
                       new DepartureEntity("ut", "18:01", "18:06"),
                       new DepartureEntity("amf", "18:20", "18:25"),
                       new DepartureEntity("amfs", "18:29", "18:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "411", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "18:06", "18:06"),
                       new DepartureEntity("amf", "18:20", "18:20"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "412", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "17:20", "17:20"),
                       new DepartureEntity("gd", "17:37", "17:43"),
                       new DepartureEntity("ut", "18:01", "18:06"),
                       new DepartureEntity("amf", "18:20", "18:25"),
                       new DepartureEntity("amfs", "18:29", "18:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "413", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "17:23", "17:23"),
                       new DepartureEntity("gd", "17:40", "17:43"),
                       new DepartureEntity("ut", "18:01", "18:06"),
                       new DepartureEntity("amf", "18:20", "18:25"),
                       new DepartureEntity("amfs", "18:29", "18:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "414", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "17:24", "17:24"),
                       new DepartureEntity("gd", "17:41", "17:42"),
                       new DepartureEntity("ut", "18:01", "18:06"),
                       new DepartureEntity("amf", "18:20", "18:25"),
                       new DepartureEntity("amfs", "18:29", "18:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "415", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "17:23", "17:23"),
                       new DepartureEntity("gd", "17:40", "17:43"),
                       new DepartureEntity("ut", "18:01", "18:06"),
                       new DepartureEntity("amf", "18:20", "18:25"),
                       new DepartureEntity("amfs", "18:29", "18:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "416", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "18:06", "18:06"),
                       new DepartureEntity("amf", "18:20", "18:20"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "417", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "18:34", "18:34"),
                       new DepartureEntity("amf", "18:38", "18:40"),
                       new DepartureEntity("ut", "18:54", "18:59"),
                       new DepartureEntity("gd", "19:17", "19:22"),
                       new DepartureEntity("rta", "19:31", "19:31"),
                       new DepartureEntity("rtd", "19:40", "19:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "418", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "18:34", "18:34"),
                       new DepartureEntity("amf", "18:38", "18:40"),
                       new DepartureEntity("ut", "18:54", "18:59"),
                       new DepartureEntity("gd", "19:17", "19:22"),
                       new DepartureEntity("rta", "19:31", "19:31"),
                       new DepartureEntity("rtd", "19:40", "19:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "419", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "18:34", "18:34"),
                       new DepartureEntity("amf", "18:38", "18:40"),
                       new DepartureEntity("ut", "18:54", "18:59"),
                       new DepartureEntity("gd", "19:17", "19:22"),
                       new DepartureEntity("rta", "19:31", "19:31"),
                       new DepartureEntity("rtd", "19:40", "19:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "420", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "18:34", "18:34"),
                       new DepartureEntity("amf", "18:38", "18:40"),
                       new DepartureEntity("ut", "18:54", "19:02"),
                       new DepartureEntity("gd", "19:21", "19:22"),
                       new DepartureEntity("rta", "19:31", "19:31"),
                       new DepartureEntity("rtd", "19:40", "19:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "421", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "18:40", "18:40"),
                       new DepartureEntity("ut", "18:56", "18:56"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "422", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "18:34", "18:34"),
                       new DepartureEntity("amf", "18:38", "18:40"),
                       new DepartureEntity("ut", "18:54", "18:59"),
                       new DepartureEntity("gd", "19:17", "19:19"),
                       new DepartureEntity("gvc", "19:37", "19:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "423", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "18:34", "18:34"),
                       new DepartureEntity("amf", "18:38", "18:40"),
                       new DepartureEntity("ut", "18:54", "18:59"),
                       new DepartureEntity("gd", "19:18", "19:19"),
                       new DepartureEntity("gvc", "19:37", "19:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "424", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "18:34", "18:34"),
                       new DepartureEntity("amf", "18:38", "18:40"),
                       new DepartureEntity("ut", "18:54", "18:59"),
                       new DepartureEntity("gd", "19:17", "19:19"),
                       new DepartureEntity("gvc", "19:37", "19:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "425", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "18:40", "18:40"),
                       new DepartureEntity("ut", "18:56", "18:56"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "426", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "18:34", "18:34"),
                       new DepartureEntity("amf", "18:38", "18:40"),
                       new DepartureEntity("ut", "18:54", "18:59"),
                       new DepartureEntity("gd", "19:18", "19:19"),
                       new DepartureEntity("gvc", "19:37", "19:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "427", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "18:34", "18:34"),
                       new DepartureEntity("amf", "18:38", "18:40"),
                       new DepartureEntity("ut", "18:54", "18:59"),
                       new DepartureEntity("gd", "19:19", "19:20"),
                       new DepartureEntity("gvc", "19:41", "19:41"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "428", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "19:50", "19:50"),
                       new DepartureEntity("rta", "19:58", "19:58"),
                       new DepartureEntity("gd", "20:08", "20:09"),
                       new DepartureEntity("ut", "20:28", "20:36"),
                       new DepartureEntity("amf", "20:50", "20:53"),
                       new DepartureEntity("apd", "21:17", "21:18"),
                       new DepartureEntity("dv", "21:28", "21:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "429", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "19:50", "19:50"),
                       new DepartureEntity("rta", "19:58", "19:58"),
                       new DepartureEntity("gd", "20:08", "20:13"),
                       new DepartureEntity("ut", "20:31", "20:36"),
                       new DepartureEntity("amf", "20:50", "20:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "430", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "19:50", "19:50"),
                       new DepartureEntity("rta", "19:58", "19:58"),
                       new DepartureEntity("gd", "20:08", "20:13"),
                       new DepartureEntity("ut", "20:31", "20:36"),
                       new DepartureEntity("amf", "20:50", "20:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "431", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "19:50", "19:50"),
                       new DepartureEntity("rta", "19:58", "19:58"),
                       new DepartureEntity("gd", "20:08", "20:13"),
                       new DepartureEntity("ut", "20:31", "20:36"),
                       new DepartureEntity("amf", "20:50", "20:53"),
                       new DepartureEntity("apd", "21:17", "21:18"),
                       new DepartureEntity("dv", "21:28", "21:30"),
                       new DepartureEntity("aml", "21:55", "21:56"),
                       new DepartureEntity("hgl", "22:07", "22:08"),
                       new DepartureEntity("es", "22:15", "22:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "432", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "19:50", "19:50"),
                       new DepartureEntity("rta", "19:58", "19:58"),
                       new DepartureEntity("gd", "20:08", "20:13"),
                       new DepartureEntity("ut", "20:31", "20:36"),
                       new DepartureEntity("amf", "20:50", "20:53"),
                       new DepartureEntity("apd", "21:17", "21:18"),
                       new DepartureEntity("dv", "21:28", "21:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "433", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "20:36", "20:36"),
                       new DepartureEntity("amf", "20:50", "20:53"),
                       new DepartureEntity("apd", "21:17", "21:18"),
                       new DepartureEntity("dv", "21:28", "21:30"),
                       new DepartureEntity("aml", "21:55", "21:56"),
                       new DepartureEntity("hgl", "22:07", "22:08"),
                       new DepartureEntity("es", "22:15", "22:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "434", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "19:50", "19:50"),
                       new DepartureEntity("gd", "20:07", "20:13"),
                       new DepartureEntity("ut", "20:31", "20:36"),
                       new DepartureEntity("amf", "20:50", "20:53"),
                       new DepartureEntity("apd", "21:17", "21:18"),
                       new DepartureEntity("dv", "21:28", "21:30"),
                       new DepartureEntity("aml", "21:55", "21:56"),
                       new DepartureEntity("hgl", "22:07", "22:08"),
                       new DepartureEntity("es", "22:15", "22:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "435", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "19:53", "19:53"),
                       new DepartureEntity("gd", "20:10", "20:13"),
                       new DepartureEntity("ut", "20:31", "20:36"),
                       new DepartureEntity("amf", "20:50", "20:53"),
                       new DepartureEntity("apd", "21:17", "21:18"),
                       new DepartureEntity("dv", "21:28", "21:30"),
                       new DepartureEntity("aml", "21:55", "21:56"),
                       new DepartureEntity("hgl", "22:07", "22:08"),
                       new DepartureEntity("es", "22:15", "22:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "436", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "19:54", "19:54"),
                       new DepartureEntity("gd", "20:11", "20:12"),
                       new DepartureEntity("ut", "20:31", "20:36"),
                       new DepartureEntity("amf", "20:50", "20:53"),
                       new DepartureEntity("apd", "21:17", "21:18"),
                       new DepartureEntity("dv", "21:28", "21:30"),
                       new DepartureEntity("aml", "21:55", "21:56"),
                       new DepartureEntity("hgl", "22:07", "22:08"),
                       new DepartureEntity("es", "22:15", "22:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "437", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "19:53", "19:53"),
                       new DepartureEntity("gd", "20:10", "20:13"),
                       new DepartureEntity("ut", "20:31", "20:36"),
                       new DepartureEntity("amf", "20:50", "20:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "438", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "19:53", "19:53"),
                       new DepartureEntity("gd", "20:10", "20:13"),
                       new DepartureEntity("ut", "20:31", "20:36"),
                       new DepartureEntity("amf", "20:50", "20:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "439", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "19:53", "19:53"),
                       new DepartureEntity("gd", "20:10", "20:13"),
                       new DepartureEntity("ut", "20:31", "20:36"),
                       new DepartureEntity("amf", "20:50", "20:53"),
                       new DepartureEntity("apd", "21:17", "21:18"),
                       new DepartureEntity("dv", "21:28", "21:30"),
                       new DepartureEntity("aml", "21:55", "21:56"),
                       new DepartureEntity("hgl", "22:07", "22:08"),
                       new DepartureEntity("es", "22:15", "22:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "440", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "19:54", "19:54"),
                       new DepartureEntity("gd", "20:11", "20:12"),
                       new DepartureEntity("ut", "20:31", "20:36"),
                       new DepartureEntity("amf", "20:50", "20:53"),
                       new DepartureEntity("apd", "21:17", "21:18"),
                       new DepartureEntity("dv", "21:28", "21:30"),
                       new DepartureEntity("aml", "21:55", "21:56"),
                       new DepartureEntity("hgl", "22:07", "22:08"),
                       new DepartureEntity("es", "22:15", "22:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "441", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "06:59", "06:59"),
                       new DepartureEntity("gd", "07:17", "07:22"),
                       new DepartureEntity("rta", "07:31", "07:31"),
                       new DepartureEntity("rtd", "07:40", "07:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "442", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "06:59", "06:59"),
                       new DepartureEntity("gd", "07:17", "07:22"),
                       new DepartureEntity("rta", "07:31", "07:31"),
                       new DepartureEntity("rtd", "07:40", "07:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "443", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "06:34", "06:34"),
                       new DepartureEntity("amf", "06:38", "06:40"),
                       new DepartureEntity("ut", "06:54", "07:02"),
                       new DepartureEntity("gd", "07:21", "07:22"),
                       new DepartureEntity("rta", "07:31", "07:31"),
                       new DepartureEntity("rtd", "07:40", "07:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "444", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "06:34", "06:34"),
                       new DepartureEntity("amf", "06:38", "06:40"),
                       new DepartureEntity("ut", "06:54", "06:59"),
                       new DepartureEntity("gd", "07:18", "07:19"),
                       new DepartureEntity("gvc", "07:37", "07:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "445", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "06:59", "06:59"),
                       new DepartureEntity("gd", "07:17", "07:19"),
                       new DepartureEntity("gvc", "07:37", "07:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "446", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "06:59", "06:59"),
                       new DepartureEntity("gd", "07:17", "07:19"),
                       new DepartureEntity("gvc", "07:37", "07:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "447", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "06:59", "06:59"),
                       new DepartureEntity("gd", "07:19", "07:20"),
                       new DepartureEntity("gvc", "07:41", "07:41"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "448", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "07:50", "07:50"),
                       new DepartureEntity("rta", "07:58", "07:58"),
                       new DepartureEntity("gd", "08:08", "08:09"),
                       new DepartureEntity("ut", "08:28", "08:36"),
                       new DepartureEntity("amf", "08:50", "08:53"),
                       new DepartureEntity("apd", "09:17", "09:18"),
                       new DepartureEntity("dv", "09:28", "09:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "449", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "07:50", "07:50"),
                       new DepartureEntity("rta", "07:58", "07:58"),
                       new DepartureEntity("gd", "08:08", "08:13"),
                       new DepartureEntity("ut", "08:31", "08:36"),
                       new DepartureEntity("amf", "08:50", "08:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "450", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "07:50", "07:50"),
                       new DepartureEntity("rta", "07:58", "07:58"),
                       new DepartureEntity("gd", "08:08", "08:13"),
                       new DepartureEntity("ut", "08:31", "08:36"),
                       new DepartureEntity("amf", "08:50", "08:53"),
                       new DepartureEntity("apd", "09:17", "09:18"),
                       new DepartureEntity("dv", "09:28", "09:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "451", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "08:36", "08:36"),
                       new DepartureEntity("amf", "08:50", "08:53"),
                       new DepartureEntity("apd", "09:17", "09:18"),
                       new DepartureEntity("dv", "09:28", "09:30"),
                       new DepartureEntity("aml", "09:55", "09:56"),
                       new DepartureEntity("hgl", "10:07", "10:08"),
                       new DepartureEntity("es", "10:15", "10:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "452", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "07:50", "07:50"),
                       new DepartureEntity("gd", "08:07", "08:13"),
                       new DepartureEntity("ut", "08:31", "08:36"),
                       new DepartureEntity("amf", "08:50", "08:53"),
                       new DepartureEntity("apd", "09:17", "09:18"),
                       new DepartureEntity("dv", "09:28", "09:30"),
                       new DepartureEntity("aml", "09:55", "09:56"),
                       new DepartureEntity("hgl", "10:07", "10:08"),
                       new DepartureEntity("es", "10:15", "10:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "453", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "07:50", "07:50"),
                       new DepartureEntity("gd", "08:07", "08:13"),
                       new DepartureEntity("ut", "08:31", "08:36"),
                       new DepartureEntity("amf", "08:50", "08:53"),
                       new DepartureEntity("apd", "09:17", "09:18"),
                       new DepartureEntity("dv", "09:28", "09:30"),
                       new DepartureEntity("aml", "09:55", "09:56"),
                       new DepartureEntity("hgl", "10:07", "10:08"),
                       new DepartureEntity("es", "10:15", "10:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "454", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "07:53", "07:53"),
                       new DepartureEntity("gd", "08:10", "08:13"),
                       new DepartureEntity("ut", "08:31", "08:36"),
                       new DepartureEntity("amf", "08:50", "08:53"),
                       new DepartureEntity("apd", "09:17", "09:18"),
                       new DepartureEntity("dv", "09:28", "09:30"),
                       new DepartureEntity("aml", "09:55", "09:56"),
                       new DepartureEntity("hgl", "10:07", "10:08"),
                       new DepartureEntity("es", "10:15", "10:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "455", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "07:54", "07:54"),
                       new DepartureEntity("gd", "08:11", "08:12"),
                       new DepartureEntity("ut", "08:31", "08:36"),
                       new DepartureEntity("amf", "08:50", "08:53"),
                       new DepartureEntity("apd", "09:17", "09:18"),
                       new DepartureEntity("dv", "09:28", "09:30"),
                       new DepartureEntity("aml", "09:55", "09:56"),
                       new DepartureEntity("hgl", "10:07", "10:08"),
                       new DepartureEntity("es", "10:15", "10:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "456", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "07:53", "07:53"),
                       new DepartureEntity("gd", "08:10", "08:13"),
                       new DepartureEntity("ut", "08:31", "08:36"),
                       new DepartureEntity("amf", "08:50", "08:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "457", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "07:53", "07:53"),
                       new DepartureEntity("gd", "08:10", "08:13"),
                       new DepartureEntity("ut", "08:31", "08:36"),
                       new DepartureEntity("amf", "08:50", "08:53"),
                       new DepartureEntity("apd", "09:17", "09:18"),
                       new DepartureEntity("dv", "09:28", "09:30"),
                       new DepartureEntity("aml", "09:55", "09:56"),
                       new DepartureEntity("hgl", "10:07", "10:08"),
                       new DepartureEntity("es", "10:15", "10:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "458", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "07:53", "07:53"),
                       new DepartureEntity("gd", "08:10", "08:13"),
                       new DepartureEntity("ut", "08:31", "08:36"),
                       new DepartureEntity("amf", "08:50", "08:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "459", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "11:10", "11:10"),
                       new DepartureEntity("ut", "11:24", "11:29"),
                       new DepartureEntity("gd", "11:47", "11:52"),
                       new DepartureEntity("rta", "12:01", "12:01"),
                       new DepartureEntity("rtd", "12:10", "12:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "460", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "11:10", "11:10"),
                       new DepartureEntity("ut", "11:24", "11:29"),
                       new DepartureEntity("gd", "11:47", "11:52"),
                       new DepartureEntity("rta", "12:01", "12:01"),
                       new DepartureEntity("rtd", "12:10", "12:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "461", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "09:46", "09:46"),
                       new DepartureEntity("hgl", "09:53", "09:54"),
                       new DepartureEntity("aml", "10:05", "10:06"),
                       new DepartureEntity("dv", "10:29", "10:32"),
                       new DepartureEntity("apd", "10:42", "10:43"),
                       new DepartureEntity("amf", "11:07", "11:10"),
                       new DepartureEntity("ut", "11:24", "11:29"),
                       new DepartureEntity("gd", "11:47", "11:52"),
                       new DepartureEntity("rta", "12:01", "12:01"),
                       new DepartureEntity("rtd", "12:10", "12:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "462", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "10:32", "10:32"),
                       new DepartureEntity("apd", "10:42", "10:43"),
                       new DepartureEntity("amf", "11:07", "11:10"),
                       new DepartureEntity("ut", "11:24", "11:29"),
                       new DepartureEntity("gd", "11:47", "11:52"),
                       new DepartureEntity("rta", "12:01", "12:02"),
                       new DepartureEntity("rtd", "12:10", "12:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "463", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "10:32", "10:32"),
                       new DepartureEntity("apd", "10:42", "10:43"),
                       new DepartureEntity("amf", "11:07", "11:10"),
                       new DepartureEntity("ut", "11:24", "11:29"),
                       new DepartureEntity("gd", "11:47", "11:52"),
                       new DepartureEntity("rta", "12:01", "12:01"),
                       new DepartureEntity("rtd", "12:10", "12:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "464", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "10:32", "10:32"),
                       new DepartureEntity("apd", "10:42", "10:43"),
                       new DepartureEntity("amf", "11:07", "11:10"),
                       new DepartureEntity("ut", "11:24", "11:32"),
                       new DepartureEntity("gd", "11:51", "11:52"),
                       new DepartureEntity("rta", "12:01", "12:01"),
                       new DepartureEntity("rtd", "12:10", "12:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "465", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "11:10", "11:10"),
                       new DepartureEntity("ut", "11:24", "11:29"),
                       new DepartureEntity("gd", "11:47", "11:49"),
                       new DepartureEntity("gvc", "12:07", "12:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "466", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "09:46", "09:46"),
                       new DepartureEntity("hgl", "09:53", "09:54"),
                       new DepartureEntity("aml", "10:05", "10:06"),
                       new DepartureEntity("dv", "10:29", "10:32"),
                       new DepartureEntity("apd", "10:42", "10:43"),
                       new DepartureEntity("amf", "11:07", "11:10"),
                       new DepartureEntity("ut", "11:26", "11:26"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "467", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "09:46", "09:46"),
                       new DepartureEntity("hgl", "09:53", "09:54"),
                       new DepartureEntity("aml", "10:05", "10:06"),
                       new DepartureEntity("dv", "10:29", "10:32"),
                       new DepartureEntity("apd", "10:42", "10:43"),
                       new DepartureEntity("amf", "11:07", "11:10"),
                       new DepartureEntity("ut", "11:24", "11:29"),
                       new DepartureEntity("gd", "11:49", "11:50"),
                       new DepartureEntity("gvc", "12:11", "12:11"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "468", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "09:46", "09:46"),
                       new DepartureEntity("hgl", "09:53", "09:54"),
                       new DepartureEntity("aml", "10:05", "10:06"),
                       new DepartureEntity("dv", "10:29", "10:32"),
                       new DepartureEntity("apd", "10:42", "10:43"),
                       new DepartureEntity("amf", "11:07", "11:10"),
                       new DepartureEntity("ut", "11:24", "11:29"),
                       new DepartureEntity("gd", "11:48", "11:49"),
                       new DepartureEntity("gvc", "12:07", "12:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "469", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "09:46", "09:46"),
                       new DepartureEntity("hgl", "09:53", "09:54"),
                       new DepartureEntity("aml", "10:05", "10:06"),
                       new DepartureEntity("dv", "10:29", "10:32"),
                       new DepartureEntity("apd", "10:42", "10:43"),
                       new DepartureEntity("amf", "11:07", "11:10"),
                       new DepartureEntity("ut", "11:24", "11:29"),
                       new DepartureEntity("gd", "11:48", "11:49"),
                       new DepartureEntity("gvc", "12:07", "12:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "470", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "09:46", "09:46"),
                       new DepartureEntity("hgl", "09:53", "09:54"),
                       new DepartureEntity("aml", "10:05", "10:06"),
                       new DepartureEntity("dv", "10:29", "10:32"),
                       new DepartureEntity("apd", "10:42", "10:43"),
                       new DepartureEntity("amf", "11:07", "11:10"),
                       new DepartureEntity("ut", "11:24", "11:29"),
                       new DepartureEntity("gd", "11:47", "11:49"),
                       new DepartureEntity("gvc", "12:07", "12:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "471", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "09:46", "09:46"),
                       new DepartureEntity("hgl", "09:53", "09:54"),
                       new DepartureEntity("aml", "10:05", "10:06"),
                       new DepartureEntity("dv", "10:29", "10:32"),
                       new DepartureEntity("apd", "10:42", "10:43"),
                       new DepartureEntity("amf", "11:07", "11:10"),
                       new DepartureEntity("ut", "11:26", "11:26"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "472", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "11:10", "11:10"),
                       new DepartureEntity("ut", "11:24", "11:29"),
                       new DepartureEntity("gd", "11:47", "11:49"),
                       new DepartureEntity("gvc", "12:10", "12:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "473", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "09:46", "09:46"),
                       new DepartureEntity("hgl", "09:53", "09:54"),
                       new DepartureEntity("aml", "10:05", "10:06"),
                       new DepartureEntity("dv", "10:29", "10:32"),
                       new DepartureEntity("apd", "10:42", "10:43"),
                       new DepartureEntity("amf", "11:07", "11:10"),
                       new DepartureEntity("ut", "11:24", "11:29"),
                       new DepartureEntity("gd", "11:47", "11:49"),
                       new DepartureEntity("gvc", "12:07", "12:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "474", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "09:46", "09:46"),
                       new DepartureEntity("hgl", "09:53", "09:54"),
                       new DepartureEntity("aml", "10:05", "10:06"),
                       new DepartureEntity("dv", "10:29", "10:32"),
                       new DepartureEntity("apd", "10:42", "10:43"),
                       new DepartureEntity("amf", "11:07", "11:10"),
                       new DepartureEntity("ut", "11:24", "11:29"),
                       new DepartureEntity("gd", "11:48", "11:49"),
                       new DepartureEntity("gvc", "12:07", "12:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "475", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "09:46", "09:46"),
                       new DepartureEntity("hgl", "09:53", "09:54"),
                       new DepartureEntity("aml", "10:05", "10:06"),
                       new DepartureEntity("dv", "10:29", "10:32"),
                       new DepartureEntity("apd", "10:42", "10:43"),
                       new DepartureEntity("amf", "11:07", "11:10"),
                       new DepartureEntity("ut", "11:24", "11:29"),
                       new DepartureEntity("gd", "11:48", "11:49"),
                       new DepartureEntity("gvc", "12:07", "12:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "476", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "09:46", "09:46"),
                       new DepartureEntity("hgl", "09:53", "09:54"),
                       new DepartureEntity("aml", "10:05", "10:06"),
                       new DepartureEntity("dv", "10:29", "10:32"),
                       new DepartureEntity("apd", "10:42", "10:43"),
                       new DepartureEntity("amf", "11:07", "11:10"),
                       new DepartureEntity("ut", "11:24", "11:29"),
                       new DepartureEntity("gd", "11:49", "11:50"),
                       new DepartureEntity("gvc", "12:11", "12:11"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "477", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "12:20", "12:20"),
                       new DepartureEntity("rta", "12:28", "12:28"),
                       new DepartureEntity("gd", "12:38", "12:39"),
                       new DepartureEntity("ut", "12:58", "13:06"),
                       new DepartureEntity("amf", "13:20", "13:25"),
                       new DepartureEntity("amfs", "13:29", "13:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "478", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "12:20", "12:20"),
                       new DepartureEntity("rta", "12:28", "12:28"),
                       new DepartureEntity("gd", "12:38", "12:44"),
                       new DepartureEntity("ut", "13:02", "13:07"),
                       new DepartureEntity("amf", "13:20", "13:25"),
                       new DepartureEntity("amfs", "13:29", "13:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "479", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "12:20", "12:20"),
                       new DepartureEntity("rta", "12:28", "12:28"),
                       new DepartureEntity("gd", "12:38", "12:43"),
                       new DepartureEntity("ut", "13:01", "13:06"),
                       new DepartureEntity("amf", "13:20", "13:25"),
                       new DepartureEntity("amfs", "13:29", "13:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "480", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "13:06", "13:06"),
                       new DepartureEntity("amf", "13:20", "13:20"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "481", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "12:23", "12:23"),
                       new DepartureEntity("gd", "12:40", "12:43"),
                       new DepartureEntity("ut", "13:01", "13:06"),
                       new DepartureEntity("amf", "13:20", "13:25"),
                       new DepartureEntity("amfs", "13:29", "13:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "482", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "12:20", "12:20"),
                       new DepartureEntity("gd", "12:37", "12:43"),
                       new DepartureEntity("ut", "13:01", "13:06"),
                       new DepartureEntity("amf", "13:20", "13:25"),
                       new DepartureEntity("amfs", "13:29", "13:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "483", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "12:23", "12:23"),
                       new DepartureEntity("gd", "12:40", "12:43"),
                       new DepartureEntity("ut", "13:01", "13:06"),
                       new DepartureEntity("amf", "13:20", "13:25"),
                       new DepartureEntity("amfs", "13:29", "13:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "484", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "12:24", "12:24"),
                       new DepartureEntity("gd", "12:41", "12:42"),
                       new DepartureEntity("ut", "13:01", "13:06"),
                       new DepartureEntity("amf", "13:20", "13:25"),
                       new DepartureEntity("amfs", "13:29", "13:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "485", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "12:23", "12:23"),
                       new DepartureEntity("gd", "12:43", "12:44"),
                       new DepartureEntity("ut", "13:02", "13:07"),
                       new DepartureEntity("amf", "13:20", "13:25"),
                       new DepartureEntity("amfs", "13:29", "13:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "486", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "12:20", "12:20"),
                       new DepartureEntity("gd", "12:37", "12:43"),
                       new DepartureEntity("ut", "13:01", "13:06"),
                       new DepartureEntity("amf", "13:20", "13:25"),
                       new DepartureEntity("amfs", "13:29", "13:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "487", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "13:06", "13:06"),
                       new DepartureEntity("amf", "13:20", "13:20"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "488", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "13:34", "13:34"),
                       new DepartureEntity("amf", "13:38", "13:40"),
                       new DepartureEntity("ut", "13:54", "13:59"),
                       new DepartureEntity("gd", "14:17", "14:22"),
                       new DepartureEntity("rta", "14:31", "14:31"),
                       new DepartureEntity("rtd", "14:40", "14:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "489", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "13:34", "13:34"),
                       new DepartureEntity("amf", "13:38", "13:40"),
                       new DepartureEntity("ut", "13:54", "13:59"),
                       new DepartureEntity("gd", "14:17", "14:22"),
                       new DepartureEntity("rta", "14:31", "14:31"),
                       new DepartureEntity("rtd", "14:40", "14:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "490", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "13:34", "13:34"),
                       new DepartureEntity("amf", "13:38", "13:40"),
                       new DepartureEntity("ut", "13:54", "13:59"),
                       new DepartureEntity("gd", "14:17", "14:22"),
                       new DepartureEntity("rta", "14:31", "14:31"),
                       new DepartureEntity("rtd", "14:40", "14:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "491", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "13:34", "13:34"),
                       new DepartureEntity("amf", "13:38", "13:40"),
                       new DepartureEntity("ut", "13:54", "14:02"),
                       new DepartureEntity("gd", "14:21", "14:22"),
                       new DepartureEntity("rta", "14:31", "14:31"),
                       new DepartureEntity("rtd", "14:40", "14:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "492", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "13:40", "13:40"),
                       new DepartureEntity("ut", "13:56", "13:56"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "493", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "13:34", "13:34"),
                       new DepartureEntity("amf", "13:38", "13:40"),
                       new DepartureEntity("ut", "13:54", "13:59"),
                       new DepartureEntity("gd", "14:17", "14:19"),
                       new DepartureEntity("gvc", "14:37", "14:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "494", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "13:34", "13:34"),
                       new DepartureEntity("amf", "13:38", "13:40"),
                       new DepartureEntity("ut", "13:54", "13:59"),
                       new DepartureEntity("gd", "14:19", "14:20"),
                       new DepartureEntity("gvc", "14:41", "14:41"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "495", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "13:34", "13:34"),
                       new DepartureEntity("amf", "13:38", "13:40"),
                       new DepartureEntity("ut", "13:54", "13:59"),
                       new DepartureEntity("gd", "14:17", "14:19"),
                       new DepartureEntity("gvc", "14:37", "14:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "496", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "13:40", "13:40"),
                       new DepartureEntity("ut", "13:56", "13:56"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "497", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "13:34", "13:34"),
                       new DepartureEntity("amf", "13:38", "13:40"),
                       new DepartureEntity("ut", "13:54", "13:59"),
                       new DepartureEntity("gd", "14:18", "14:19"),
                       new DepartureEntity("gvc", "14:37", "14:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "498", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "13:34", "13:34"),
                       new DepartureEntity("amf", "13:38", "13:40"),
                       new DepartureEntity("ut", "13:54", "13:59"),
                       new DepartureEntity("gd", "14:18", "14:19"),
                       new DepartureEntity("gvc", "14:37", "14:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "499", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "13:34", "13:34"),
                       new DepartureEntity("amf", "13:38", "13:40"),
                       new DepartureEntity("ut", "13:54", "13:59"),
                       new DepartureEntity("gd", "14:19", "14:20"),
                       new DepartureEntity("gvc", "14:41", "14:41"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "500", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "13:34", "13:34"),
                       new DepartureEntity("amf", "13:38", "13:40"),
                       new DepartureEntity("ut", "13:54", "13:59"),
                       new DepartureEntity("gd", "14:17", "14:19"),
                       new DepartureEntity("gvc", "14:40", "14:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "501", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "14:50", "14:50"),
                       new DepartureEntity("rta", "14:58", "14:58"),
                       new DepartureEntity("gd", "15:08", "15:09"),
                       new DepartureEntity("ut", "15:28", "15:36"),
                       new DepartureEntity("amf", "15:50", "15:53"),
                       new DepartureEntity("apd", "16:17", "16:18"),
                       new DepartureEntity("dv", "16:28", "16:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "502", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "14:50", "14:50"),
                       new DepartureEntity("rta", "14:58", "14:58"),
                       new DepartureEntity("gd", "15:08", "15:13"),
                       new DepartureEntity("ut", "15:31", "15:36"),
                       new DepartureEntity("amf", "15:50", "15:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "503", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "14:50", "14:50"),
                       new DepartureEntity("rta", "14:58", "14:58"),
                       new DepartureEntity("gd", "15:08", "15:13"),
                       new DepartureEntity("ut", "15:31", "15:36"),
                       new DepartureEntity("amf", "15:50", "15:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "504", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "14:50", "14:50"),
                       new DepartureEntity("rta", "14:58", "14:58"),
                       new DepartureEntity("gd", "15:08", "15:13"),
                       new DepartureEntity("ut", "15:31", "15:36"),
                       new DepartureEntity("amf", "15:50", "15:53"),
                       new DepartureEntity("apd", "16:17", "16:18"),
                       new DepartureEntity("dv", "16:28", "16:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "505", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "15:36", "15:36"),
                       new DepartureEntity("amf", "15:50", "15:53"),
                       new DepartureEntity("apd", "16:17", "16:18"),
                       new DepartureEntity("dv", "16:28", "16:30"),
                       new DepartureEntity("aml", "16:55", "16:56"),
                       new DepartureEntity("hgl", "17:07", "17:08"),
                       new DepartureEntity("es", "17:15", "17:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "506", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "14:53", "14:53"),
                       new DepartureEntity("gd", "15:10", "15:13"),
                       new DepartureEntity("ut", "15:31", "15:36"),
                       new DepartureEntity("amf", "15:50", "15:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "507", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "14:50", "14:50"),
                       new DepartureEntity("gd", "15:07", "15:13"),
                       new DepartureEntity("ut", "15:31", "15:36"),
                       new DepartureEntity("amf", "15:50", "15:53"),
                       new DepartureEntity("apd", "16:17", "16:18"),
                       new DepartureEntity("dv", "16:28", "16:30"),
                       new DepartureEntity("aml", "16:55", "16:56"),
                       new DepartureEntity("hgl", "17:07", "17:08"),
                       new DepartureEntity("es", "17:15", "17:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "508", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "14:53", "14:53"),
                       new DepartureEntity("gd", "15:10", "15:13"),
                       new DepartureEntity("ut", "15:31", "15:36"),
                       new DepartureEntity("amf", "15:50", "15:53"),
                       new DepartureEntity("apd", "16:17", "16:18"),
                       new DepartureEntity("dv", "16:28", "16:30"),
                       new DepartureEntity("aml", "16:55", "16:56"),
                       new DepartureEntity("hgl", "17:07", "17:08"),
                       new DepartureEntity("es", "17:15", "17:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "509", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "14:54", "14:54"),
                       new DepartureEntity("gd", "15:11", "15:12"),
                       new DepartureEntity("ut", "15:31", "15:36"),
                       new DepartureEntity("amf", "15:50", "15:53"),
                       new DepartureEntity("apd", "16:17", "16:18"),
                       new DepartureEntity("dv", "16:28", "16:30"),
                       new DepartureEntity("aml", "16:55", "16:56"),
                       new DepartureEntity("hgl", "17:07", "17:08"),
                       new DepartureEntity("es", "17:15", "17:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "510", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "14:53", "14:53"),
                       new DepartureEntity("gd", "15:10", "15:13"),
                       new DepartureEntity("ut", "15:31", "15:36"),
                       new DepartureEntity("amf", "15:50", "15:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "511", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "14:50", "14:50"),
                       new DepartureEntity("gd", "15:07", "15:13"),
                       new DepartureEntity("ut", "15:31", "15:36"),
                       new DepartureEntity("amf", "15:50", "15:53"),
                       new DepartureEntity("apd", "16:17", "16:18"),
                       new DepartureEntity("dv", "16:28", "16:30"),
                       new DepartureEntity("aml", "16:55", "16:56"),
                       new DepartureEntity("hgl", "17:07", "17:08"),
                       new DepartureEntity("es", "17:15", "17:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "512", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "14:54", "14:54"),
                       new DepartureEntity("gd", "15:11", "15:12"),
                       new DepartureEntity("ut", "15:31", "15:36"),
                       new DepartureEntity("amf", "15:50", "15:53"),
                       new DepartureEntity("apd", "16:17", "16:18"),
                       new DepartureEntity("dv", "16:28", "16:30"),
                       new DepartureEntity("aml", "16:55", "16:56"),
                       new DepartureEntity("hgl", "17:07", "17:08"),
                       new DepartureEntity("es", "17:15", "17:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "513", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "19:10", "19:10"),
                       new DepartureEntity("ut", "19:24", "19:29"),
                       new DepartureEntity("gd", "19:47", "19:52"),
                       new DepartureEntity("rta", "20:01", "20:01"),
                       new DepartureEntity("rtd", "20:10", "20:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "514", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "18:32", "18:32"),
                       new DepartureEntity("apd", "18:42", "18:43"),
                       new DepartureEntity("amf", "19:07", "19:10"),
                       new DepartureEntity("ut", "19:24", "19:29"),
                       new DepartureEntity("gd", "19:47", "19:52"),
                       new DepartureEntity("rta", "20:01", "20:01"),
                       new DepartureEntity("rtd", "20:10", "20:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "515", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "18:32", "18:32"),
                       new DepartureEntity("apd", "18:42", "18:43"),
                       new DepartureEntity("amf", "19:07", "19:10"),
                       new DepartureEntity("ut", "19:24", "19:29"),
                       new DepartureEntity("gd", "19:47", "19:52"),
                       new DepartureEntity("rta", "20:01", "20:01"),
                       new DepartureEntity("rtd", "20:10", "20:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "516", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "18:32", "18:32"),
                       new DepartureEntity("apd", "18:42", "18:43"),
                       new DepartureEntity("amf", "19:07", "19:10"),
                       new DepartureEntity("ut", "19:24", "19:32"),
                       new DepartureEntity("gd", "19:51", "19:52"),
                       new DepartureEntity("rta", "20:01", "20:01"),
                       new DepartureEntity("rtd", "20:10", "20:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "517", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "18:32", "18:32"),
                       new DepartureEntity("apd", "18:42", "18:43"),
                       new DepartureEntity("amf", "19:07", "19:10"),
                       new DepartureEntity("ut", "19:24", "19:32"),
                       new DepartureEntity("gd", "19:51", "19:52"),
                       new DepartureEntity("rta", "20:01", "20:01"),
                       new DepartureEntity("rtd", "20:10", "20:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "518", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "18:32", "18:32"),
                       new DepartureEntity("apd", "18:42", "18:43"),
                       new DepartureEntity("amf", "19:07", "19:10"),
                       new DepartureEntity("ut", "19:24", "19:32"),
                       new DepartureEntity("gd", "19:51", "19:52"),
                       new DepartureEntity("rta", "20:01", "20:01"),
                       new DepartureEntity("rtd", "20:10", "20:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "519", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "19:10", "19:10"),
                       new DepartureEntity("ut", "19:24", "19:29"),
                       new DepartureEntity("gd", "19:47", "19:49"),
                       new DepartureEntity("gvc", "20:07", "20:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "520", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "17:46", "17:46"),
                       new DepartureEntity("hgl", "17:53", "17:54"),
                       new DepartureEntity("aml", "18:05", "18:06"),
                       new DepartureEntity("dv", "18:29", "18:32"),
                       new DepartureEntity("apd", "18:42", "18:43"),
                       new DepartureEntity("amf", "19:07", "19:10"),
                       new DepartureEntity("ut", "19:24", "19:29"),
                       new DepartureEntity("gd", "19:48", "19:49"),
                       new DepartureEntity("gvc", "20:07", "20:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "521", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "17:46", "17:46"),
                       new DepartureEntity("hgl", "17:53", "17:54"),
                       new DepartureEntity("aml", "18:05", "18:06"),
                       new DepartureEntity("dv", "18:29", "18:32"),
                       new DepartureEntity("apd", "18:42", "18:43"),
                       new DepartureEntity("amf", "19:07", "19:10"),
                       new DepartureEntity("ut", "19:24", "19:29"),
                       new DepartureEntity("gd", "19:47", "19:49"),
                       new DepartureEntity("gvc", "20:07", "20:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "522", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "17:46", "17:46"),
                       new DepartureEntity("hgl", "17:53", "17:54"),
                       new DepartureEntity("aml", "18:05", "18:06"),
                       new DepartureEntity("dv", "18:29", "18:32"),
                       new DepartureEntity("apd", "18:42", "18:43"),
                       new DepartureEntity("amf", "19:07", "19:10"),
                       new DepartureEntity("ut", "19:24", "19:29"),
                       new DepartureEntity("gd", "19:48", "19:49"),
                       new DepartureEntity("gvc", "20:07", "20:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "523", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "17:46", "17:46"),
                       new DepartureEntity("hgl", "17:53", "17:54"),
                       new DepartureEntity("aml", "18:05", "18:06"),
                       new DepartureEntity("dv", "18:29", "18:32"),
                       new DepartureEntity("apd", "18:42", "18:43"),
                       new DepartureEntity("amf", "19:07", "19:10"),
                       new DepartureEntity("ut", "19:24", "19:29"),
                       new DepartureEntity("gd", "19:49", "19:50"),
                       new DepartureEntity("gvc", "20:11", "20:11"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "524", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "17:46", "17:46"),
                       new DepartureEntity("hgl", "17:53", "17:54"),
                       new DepartureEntity("aml", "18:05", "18:06"),
                       new DepartureEntity("dv", "18:29", "18:32"),
                       new DepartureEntity("apd", "18:42", "18:43"),
                       new DepartureEntity("amf", "19:07", "19:10"),
                       new DepartureEntity("ut", "19:26", "19:26"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "525", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "17:46", "17:46"),
                       new DepartureEntity("hgl", "17:53", "17:54"),
                       new DepartureEntity("aml", "18:05", "18:06"),
                       new DepartureEntity("dv", "18:29", "18:32"),
                       new DepartureEntity("apd", "18:42", "18:43"),
                       new DepartureEntity("amf", "19:07", "19:10"),
                       new DepartureEntity("ut", "19:24", "19:29"),
                       new DepartureEntity("gd", "19:48", "19:49"),
                       new DepartureEntity("gvc", "20:07", "20:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "526", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "17:46", "17:46"),
                       new DepartureEntity("hgl", "17:53", "17:54"),
                       new DepartureEntity("aml", "18:05", "18:06"),
                       new DepartureEntity("dv", "18:29", "18:32"),
                       new DepartureEntity("apd", "18:42", "18:43"),
                       new DepartureEntity("amf", "19:07", "19:10"),
                       new DepartureEntity("ut", "19:24", "19:29"),
                       new DepartureEntity("gd", "19:48", "19:49"),
                       new DepartureEntity("gvc", "20:07", "20:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "527", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "17:46", "17:46"),
                       new DepartureEntity("hgl", "17:53", "17:54"),
                       new DepartureEntity("aml", "18:05", "18:06"),
                       new DepartureEntity("dv", "18:29", "18:32"),
                       new DepartureEntity("apd", "18:42", "18:43"),
                       new DepartureEntity("amf", "19:07", "19:10"),
                       new DepartureEntity("ut", "19:24", "19:29"),
                       new DepartureEntity("gd", "19:48", "19:49"),
                       new DepartureEntity("gvc", "20:07", "20:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "528", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "17:46", "17:46"),
                       new DepartureEntity("hgl", "17:53", "17:54"),
                       new DepartureEntity("aml", "18:05", "18:06"),
                       new DepartureEntity("dv", "18:29", "18:32"),
                       new DepartureEntity("apd", "18:42", "18:43"),
                       new DepartureEntity("amf", "19:07", "19:10"),
                       new DepartureEntity("ut", "19:24", "19:29"),
                       new DepartureEntity("gd", "19:48", "19:49"),
                       new DepartureEntity("gvc", "20:07", "20:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "529", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "17:46", "17:46"),
                       new DepartureEntity("hgl", "17:53", "17:54"),
                       new DepartureEntity("aml", "18:05", "18:06"),
                       new DepartureEntity("dv", "18:29", "18:32"),
                       new DepartureEntity("apd", "18:42", "18:43"),
                       new DepartureEntity("amf", "19:07", "19:10"),
                       new DepartureEntity("ut", "19:24", "19:29"),
                       new DepartureEntity("gd", "19:49", "19:50"),
                       new DepartureEntity("gvc", "20:11", "20:11"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "530", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "17:46", "17:46"),
                       new DepartureEntity("hgl", "17:53", "17:54"),
                       new DepartureEntity("aml", "18:05", "18:06"),
                       new DepartureEntity("dv", "18:29", "18:32"),
                       new DepartureEntity("apd", "18:42", "18:43"),
                       new DepartureEntity("amf", "19:07", "19:10"),
                       new DepartureEntity("ut", "19:24", "19:29"),
                       new DepartureEntity("gd", "19:48", "19:49"),
                       new DepartureEntity("gvc", "20:07", "20:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "531", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "17:46", "17:46"),
                       new DepartureEntity("hgl", "17:53", "17:54"),
                       new DepartureEntity("aml", "18:05", "18:06"),
                       new DepartureEntity("dv", "18:29", "18:32"),
                       new DepartureEntity("apd", "18:42", "18:43"),
                       new DepartureEntity("amf", "19:07", "19:10"),
                       new DepartureEntity("ut", "19:24", "19:29"),
                       new DepartureEntity("gd", "19:48", "19:49"),
                       new DepartureEntity("gvc", "20:07", "20:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "532", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "20:20", "20:20"),
                       new DepartureEntity("rta", "20:28", "20:28"),
                       new DepartureEntity("gd", "20:38", "20:39"),
                       new DepartureEntity("ut", "20:58", "21:06"),
                       new DepartureEntity("amf", "21:20", "21:25"),
                       new DepartureEntity("amfs", "21:29", "21:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "533", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "20:20", "20:20"),
                       new DepartureEntity("rta", "20:28", "20:28"),
                       new DepartureEntity("gd", "20:38", "20:39"),
                       new DepartureEntity("ut", "20:58", "21:06"),
                       new DepartureEntity("amf", "21:20", "21:25"),
                       new DepartureEntity("amfs", "21:29", "21:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "534", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "20:20", "20:20"),
                       new DepartureEntity("rta", "20:28", "20:28"),
                       new DepartureEntity("gd", "20:38", "20:39"),
                       new DepartureEntity("ut", "20:58", "21:06"),
                       new DepartureEntity("amf", "21:20", "21:25"),
                       new DepartureEntity("amfs", "21:29", "21:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "535", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "20:20", "20:20"),
                       new DepartureEntity("rta", "20:28", "20:28"),
                       new DepartureEntity("gd", "20:38", "20:43"),
                       new DepartureEntity("ut", "21:01", "21:06"),
                       new DepartureEntity("amf", "21:20", "21:25"),
                       new DepartureEntity("amfs", "21:29", "21:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "536", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "20:20", "20:20"),
                       new DepartureEntity("rta", "20:28", "20:28"),
                       new DepartureEntity("gd", "20:38", "20:43"),
                       new DepartureEntity("ut", "21:01", "21:06"),
                       new DepartureEntity("amf", "21:20", "21:25"),
                       new DepartureEntity("amfs", "21:29", "21:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "537", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "21:06", "21:06"),
                       new DepartureEntity("amf", "21:20", "21:20"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "538", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "20:20", "20:20"),
                       new DepartureEntity("gd", "20:37", "20:43"),
                       new DepartureEntity("ut", "21:01", "21:06"),
                       new DepartureEntity("amf", "21:20", "21:25"),
                       new DepartureEntity("amfs", "21:29", "21:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "539", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "20:23", "20:23"),
                       new DepartureEntity("gd", "20:40", "20:43"),
                       new DepartureEntity("ut", "21:01", "21:06"),
                       new DepartureEntity("amf", "21:20", "21:25"),
                       new DepartureEntity("amfs", "21:29", "21:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "540", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "20:24", "20:24"),
                       new DepartureEntity("gd", "20:41", "20:42"),
                       new DepartureEntity("ut", "21:01", "21:06"),
                       new DepartureEntity("amf", "21:20", "21:25"),
                       new DepartureEntity("amfs", "21:29", "21:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "541", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "20:24", "20:24"),
                       new DepartureEntity("gd", "20:41", "20:42"),
                       new DepartureEntity("ut", "21:01", "21:06"),
                       new DepartureEntity("amf", "21:20", "21:25"),
                       new DepartureEntity("amfs", "21:29", "21:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "542", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "20:23", "20:23"),
                       new DepartureEntity("gd", "20:40", "20:43"),
                       new DepartureEntity("ut", "21:01", "21:06"),
                       new DepartureEntity("amf", "21:20", "21:25"),
                       new DepartureEntity("amfs", "21:29", "21:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "543", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "20:24", "20:24"),
                       new DepartureEntity("gd", "20:41", "20:42"),
                       new DepartureEntity("ut", "21:01", "21:06"),
                       new DepartureEntity("amf", "21:20", "21:25"),
                       new DepartureEntity("amfs", "21:29", "21:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "544", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "06:20", "06:20"),
                       new DepartureEntity("rta", "06:28", "06:28"),
                       new DepartureEntity("gd", "06:38", "06:39"),
                       new DepartureEntity("ut", "06:58", "07:06"),
                       new DepartureEntity("amf", "07:20", "07:25"),
                       new DepartureEntity("amfs", "07:29", "07:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "545", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "06:20", "06:20"),
                       new DepartureEntity("rta", "06:28", "06:28"),
                       new DepartureEntity("gd", "06:38", "06:39"),
                       new DepartureEntity("ut", "06:58", "07:06"),
                       new DepartureEntity("amf", "07:20", "07:25"),
                       new DepartureEntity("amfs", "07:29", "07:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "546", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "06:20", "06:20"),
                       new DepartureEntity("rta", "06:28", "06:28"),
                       new DepartureEntity("gd", "06:38", "06:39"),
                       new DepartureEntity("ut", "06:58", "07:06"),
                       new DepartureEntity("amf", "07:20", "07:25"),
                       new DepartureEntity("amfs", "07:29", "07:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "547", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "06:24", "06:24"),
                       new DepartureEntity("gd", "06:41", "06:42"),
                       new DepartureEntity("ut", "07:01", "07:06"),
                       new DepartureEntity("amf", "07:20", "07:25"),
                       new DepartureEntity("amfs", "07:29", "07:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "548", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "07:06", "07:06"),
                       new DepartureEntity("amf", "07:20", "07:25"),
                       new DepartureEntity("amfs", "07:29", "07:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "549", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "07:06", "07:06"),
                       new DepartureEntity("amf", "07:20", "07:25"),
                       new DepartureEntity("amfs", "07:29", "07:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "550", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "07:34", "07:34"),
                       new DepartureEntity("amf", "07:38", "07:40"),
                       new DepartureEntity("ut", "07:54", "07:59"),
                       new DepartureEntity("gd", "08:17", "08:22"),
                       new DepartureEntity("rta", "08:31", "08:31"),
                       new DepartureEntity("rtd", "08:40", "08:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "551", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "07:34", "07:34"),
                       new DepartureEntity("amf", "07:38", "07:40"),
                       new DepartureEntity("ut", "07:54", "07:59"),
                       new DepartureEntity("gd", "08:17", "08:22"),
                       new DepartureEntity("rta", "08:31", "08:31"),
                       new DepartureEntity("rtd", "08:40", "08:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "552", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "07:34", "07:34"),
                       new DepartureEntity("amf", "07:38", "07:40"),
                       new DepartureEntity("ut", "07:54", "08:02"),
                       new DepartureEntity("gd", "08:21", "08:22"),
                       new DepartureEntity("rta", "08:31", "08:31"),
                       new DepartureEntity("rtd", "08:40", "08:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "553", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "07:34", "07:34"),
                       new DepartureEntity("amf", "07:38", "07:40"),
                       new DepartureEntity("ut", "07:54", "07:59"),
                       new DepartureEntity("gd", "08:18", "08:19"),
                       new DepartureEntity("gvc", "08:37", "08:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "554", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "07:34", "07:34"),
                       new DepartureEntity("amf", "07:38", "07:40"),
                       new DepartureEntity("ut", "07:54", "07:59"),
                       new DepartureEntity("gd", "08:17", "08:19"),
                       new DepartureEntity("gvc", "08:37", "08:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "555", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "07:40", "07:40"),
                       new DepartureEntity("ut", "07:56", "07:56"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "556", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "07:34", "07:34"),
                       new DepartureEntity("amf", "07:38", "07:40"),
                       new DepartureEntity("ut", "07:54", "07:59"),
                       new DepartureEntity("gd", "08:18", "08:19"),
                       new DepartureEntity("gvc", "08:37", "08:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "557", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "07:34", "07:34"),
                       new DepartureEntity("amf", "07:38", "07:40"),
                       new DepartureEntity("ut", "07:54", "07:59"),
                       new DepartureEntity("gd", "08:19", "08:20"),
                       new DepartureEntity("gvc", "08:41", "08:41"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "558", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "08:50", "08:50"),
                       new DepartureEntity("rta", "08:58", "08:58"),
                       new DepartureEntity("gd", "09:08", "09:09"),
                       new DepartureEntity("ut", "09:28", "09:36"),
                       new DepartureEntity("amf", "09:50", "09:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "559", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "08:50", "08:50"),
                       new DepartureEntity("rta", "08:58", "08:58"),
                       new DepartureEntity("gd", "09:08", "09:09"),
                       new DepartureEntity("ut", "09:28", "09:36"),
                       new DepartureEntity("amf", "09:50", "09:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "560", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "08:50", "08:50"),
                       new DepartureEntity("rta", "08:58", "08:58"),
                       new DepartureEntity("gd", "09:08", "09:13"),
                       new DepartureEntity("ut", "09:31", "09:36"),
                       new DepartureEntity("amf", "09:50", "09:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "561", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "08:50", "08:50"),
                       new DepartureEntity("rta", "08:58", "08:58"),
                       new DepartureEntity("gd", "09:08", "09:13"),
                       new DepartureEntity("ut", "09:31", "09:36"),
                       new DepartureEntity("amf", "09:50", "09:53"),
                       new DepartureEntity("apd", "10:17", "10:18"),
                       new DepartureEntity("dv", "10:28", "10:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "562", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "09:36", "09:36"),
                       new DepartureEntity("amf", "09:50", "09:53"),
                       new DepartureEntity("apd", "10:17", "10:18"),
                       new DepartureEntity("dv", "10:28", "10:30"),
                       new DepartureEntity("aml", "10:55", "10:56"),
                       new DepartureEntity("hgl", "11:07", "11:08"),
                       new DepartureEntity("es", "11:15", "11:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "563", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "08:50", "08:50"),
                       new DepartureEntity("gd", "09:07", "09:13"),
                       new DepartureEntity("ut", "09:31", "09:36"),
                       new DepartureEntity("amf", "09:50", "09:53"),
                       new DepartureEntity("apd", "10:17", "10:18"),
                       new DepartureEntity("dv", "10:28", "10:30"),
                       new DepartureEntity("aml", "10:55", "10:56"),
                       new DepartureEntity("hgl", "11:07", "11:08"),
                       new DepartureEntity("es", "11:15", "11:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "564", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "08:53", "08:53"),
                       new DepartureEntity("gd", "09:10", "09:13"),
                       new DepartureEntity("ut", "09:31", "09:36"),
                       new DepartureEntity("amf", "09:50", "09:53"),
                       new DepartureEntity("apd", "10:17", "10:18"),
                       new DepartureEntity("dv", "10:28", "10:30"),
                       new DepartureEntity("aml", "10:55", "10:56"),
                       new DepartureEntity("hgl", "11:07", "11:08"),
                       new DepartureEntity("es", "11:15", "11:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "565", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "08:54", "08:54"),
                       new DepartureEntity("gd", "09:11", "09:12"),
                       new DepartureEntity("ut", "09:31", "09:36"),
                       new DepartureEntity("amf", "09:50", "09:53"),
                       new DepartureEntity("apd", "10:17", "10:18"),
                       new DepartureEntity("dv", "10:28", "10:30"),
                       new DepartureEntity("aml", "10:55", "10:56"),
                       new DepartureEntity("hgl", "11:07", "11:08"),
                       new DepartureEntity("es", "11:15", "11:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "566", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "08:53", "08:53"),
                       new DepartureEntity("gd", "09:10", "09:13"),
                       new DepartureEntity("ut", "09:31", "09:36"),
                       new DepartureEntity("amf", "09:50", "09:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "567", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "08:50", "08:50"),
                       new DepartureEntity("gd", "09:07", "09:13"),
                       new DepartureEntity("ut", "09:31", "09:36"),
                       new DepartureEntity("amf", "09:50", "09:53"),
                       new DepartureEntity("apd", "10:17", "10:18"),
                       new DepartureEntity("dv", "10:28", "10:30"),
                       new DepartureEntity("aml", "10:55", "10:56"),
                       new DepartureEntity("hgl", "11:07", "11:08"),
                       new DepartureEntity("es", "11:15", "11:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "568", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "08:53", "08:53"),
                       new DepartureEntity("gd", "09:10", "09:13"),
                       new DepartureEntity("ut", "09:31", "09:36"),
                       new DepartureEntity("amf", "09:50", "09:53"),
                       new DepartureEntity("apd", "10:17", "10:18"),
                       new DepartureEntity("dv", "10:28", "10:30"),
                       new DepartureEntity("aml", "10:55", "10:56"),
                       new DepartureEntity("hgl", "11:07", "11:08"),
                       new DepartureEntity("es", "11:15", "11:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "569", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "08:54", "08:54"),
                       new DepartureEntity("gd", "09:11", "09:12"),
                       new DepartureEntity("ut", "09:31", "09:36"),
                       new DepartureEntity("amf", "09:50", "09:53"),
                       new DepartureEntity("apd", "10:17", "10:18"),
                       new DepartureEntity("dv", "10:28", "10:30"),
                       new DepartureEntity("aml", "10:55", "10:56"),
                       new DepartureEntity("hgl", "11:07", "11:08"),
                       new DepartureEntity("es", "11:15", "11:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "570", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "08:53", "08:53"),
                       new DepartureEntity("gd", "09:10", "09:13"),
                       new DepartureEntity("ut", "09:31", "09:36"),
                       new DepartureEntity("amf", "09:50", "09:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "571", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "12:10", "12:10"),
                       new DepartureEntity("ut", "12:24", "12:29"),
                       new DepartureEntity("gd", "12:47", "12:52"),
                       new DepartureEntity("rta", "13:01", "13:01"),
                       new DepartureEntity("rtd", "13:10", "13:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "572", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "12:10", "12:10"),
                       new DepartureEntity("ut", "12:24", "12:29"),
                       new DepartureEntity("gd", "12:47", "12:52"),
                       new DepartureEntity("rta", "13:01", "13:01"),
                       new DepartureEntity("rtd", "13:10", "13:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "573", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "10:46", "10:46"),
                       new DepartureEntity("hgl", "10:53", "10:54"),
                       new DepartureEntity("aml", "11:05", "11:06"),
                       new DepartureEntity("dv", "11:29", "11:32"),
                       new DepartureEntity("apd", "11:42", "11:43"),
                       new DepartureEntity("amf", "12:07", "12:10"),
                       new DepartureEntity("ut", "12:24", "12:29"),
                       new DepartureEntity("gd", "12:47", "12:52"),
                       new DepartureEntity("rta", "13:01", "13:01"),
                       new DepartureEntity("rtd", "13:10", "13:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "574", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "11:32", "11:32"),
                       new DepartureEntity("apd", "11:42", "11:43"),
                       new DepartureEntity("amf", "12:07", "12:10"),
                       new DepartureEntity("ut", "12:24", "12:29"),
                       new DepartureEntity("gd", "12:47", "12:52"),
                       new DepartureEntity("rta", "13:01", "13:01"),
                       new DepartureEntity("rtd", "13:10", "13:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "575", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "11:32", "11:32"),
                       new DepartureEntity("apd", "11:42", "11:43"),
                       new DepartureEntity("amf", "12:07", "12:10"),
                       new DepartureEntity("ut", "12:24", "12:29"),
                       new DepartureEntity("gd", "12:47", "12:52"),
                       new DepartureEntity("rta", "13:01", "13:01"),
                       new DepartureEntity("rtd", "13:10", "13:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "576", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "12:10", "12:10"),
                       new DepartureEntity("ut", "12:24", "12:32"),
                       new DepartureEntity("gd", "12:51", "12:52"),
                       new DepartureEntity("rta", "13:01", "13:01"),
                       new DepartureEntity("rtd", "13:10", "13:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "577", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "12:10", "12:10"),
                       new DepartureEntity("ut", "12:24", "12:29"),
                       new DepartureEntity("gd", "12:47", "12:49"),
                       new DepartureEntity("gvc", "13:07", "13:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "578", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "10:46", "10:46"),
                       new DepartureEntity("hgl", "10:53", "10:54"),
                       new DepartureEntity("aml", "11:05", "11:06"),
                       new DepartureEntity("dv", "11:29", "11:32"),
                       new DepartureEntity("apd", "11:42", "11:43"),
                       new DepartureEntity("amf", "12:07", "12:10"),
                       new DepartureEntity("ut", "12:24", "12:29"),
                       new DepartureEntity("gd", "12:49", "12:50"),
                       new DepartureEntity("gvc", "13:11", "13:11"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "579", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "10:46", "10:46"),
                       new DepartureEntity("hgl", "10:53", "10:54"),
                       new DepartureEntity("aml", "11:05", "11:06"),
                       new DepartureEntity("dv", "11:29", "11:32"),
                       new DepartureEntity("apd", "11:42", "11:43"),
                       new DepartureEntity("amf", "12:07", "12:10"),
                       new DepartureEntity("ut", "12:24", "12:29"),
                       new DepartureEntity("gd", "12:48", "12:49"),
                       new DepartureEntity("gvc", "13:07", "13:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "580", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "10:46", "10:46"),
                       new DepartureEntity("hgl", "10:53", "10:54"),
                       new DepartureEntity("aml", "11:05", "11:06"),
                       new DepartureEntity("dv", "11:29", "11:32"),
                       new DepartureEntity("apd", "11:42", "11:43"),
                       new DepartureEntity("amf", "12:07", "12:10"),
                       new DepartureEntity("ut", "12:24", "12:29"),
                       new DepartureEntity("gd", "12:47", "12:49"),
                       new DepartureEntity("gvc", "13:07", "13:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "581", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "10:46", "10:46"),
                       new DepartureEntity("hgl", "10:53", "10:54"),
                       new DepartureEntity("aml", "11:05", "11:06"),
                       new DepartureEntity("dv", "11:29", "11:32"),
                       new DepartureEntity("apd", "11:42", "11:43"),
                       new DepartureEntity("amf", "12:07", "12:10"),
                       new DepartureEntity("ut", "12:26", "12:26"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "582", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "10:46", "10:46"),
                       new DepartureEntity("hgl", "10:53", "10:54"),
                       new DepartureEntity("aml", "11:05", "11:06"),
                       new DepartureEntity("dv", "11:29", "11:32"),
                       new DepartureEntity("apd", "11:42", "11:43"),
                       new DepartureEntity("amf", "12:07", "12:10"),
                       new DepartureEntity("ut", "12:24", "12:29"),
                       new DepartureEntity("gd", "12:48", "12:49"),
                       new DepartureEntity("gvc", "13:07", "13:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "583", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "10:46", "10:46"),
                       new DepartureEntity("hgl", "10:53", "10:54"),
                       new DepartureEntity("aml", "11:05", "11:06"),
                       new DepartureEntity("dv", "11:29", "11:32"),
                       new DepartureEntity("apd", "11:42", "11:43"),
                       new DepartureEntity("amf", "12:07", "12:10"),
                       new DepartureEntity("ut", "12:26", "12:26"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "584", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "12:10", "12:10"),
                       new DepartureEntity("ut", "12:24", "12:29"),
                       new DepartureEntity("gd", "12:47", "12:49"),
                       new DepartureEntity("gvc", "13:10", "13:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "585", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "10:46", "10:46"),
                       new DepartureEntity("hgl", "10:53", "10:54"),
                       new DepartureEntity("aml", "11:05", "11:06"),
                       new DepartureEntity("dv", "11:29", "11:32"),
                       new DepartureEntity("apd", "11:42", "11:43"),
                       new DepartureEntity("amf", "12:07", "12:10"),
                       new DepartureEntity("ut", "12:24", "12:29"),
                       new DepartureEntity("gd", "12:47", "12:49"),
                       new DepartureEntity("gvc", "13:07", "13:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "586", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "10:46", "10:46"),
                       new DepartureEntity("hgl", "10:53", "10:54"),
                       new DepartureEntity("aml", "11:05", "11:06"),
                       new DepartureEntity("dv", "11:29", "11:32"),
                       new DepartureEntity("apd", "11:42", "11:43"),
                       new DepartureEntity("amf", "12:07", "12:10"),
                       new DepartureEntity("ut", "12:24", "12:29"),
                       new DepartureEntity("gd", "12:48", "12:49"),
                       new DepartureEntity("gvc", "13:07", "13:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "587", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "10:46", "10:46"),
                       new DepartureEntity("hgl", "10:53", "10:54"),
                       new DepartureEntity("aml", "11:05", "11:06"),
                       new DepartureEntity("dv", "11:29", "11:32"),
                       new DepartureEntity("apd", "11:42", "11:43"),
                       new DepartureEntity("amf", "12:07", "12:10"),
                       new DepartureEntity("ut", "12:24", "12:29"),
                       new DepartureEntity("gd", "12:49", "12:50"),
                       new DepartureEntity("gvc", "13:11", "13:11"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "588", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "13:20", "13:20"),
                       new DepartureEntity("rta", "13:28", "13:28"),
                       new DepartureEntity("gd", "13:38", "13:39"),
                       new DepartureEntity("ut", "13:58", "14:06"),
                       new DepartureEntity("amf", "14:20", "14:25"),
                       new DepartureEntity("amfs", "14:29", "14:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "589", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "13:20", "13:20"),
                       new DepartureEntity("rta", "13:28", "13:28"),
                       new DepartureEntity("gd", "13:38", "13:44"),
                       new DepartureEntity("ut", "14:02", "14:07"),
                       new DepartureEntity("amf", "14:20", "14:25"),
                       new DepartureEntity("amfs", "14:29", "14:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "590", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "13:20", "13:20"),
                       new DepartureEntity("rta", "13:28", "13:28"),
                       new DepartureEntity("gd", "13:38", "13:43"),
                       new DepartureEntity("ut", "14:01", "14:06"),
                       new DepartureEntity("amf", "14:20", "14:25"),
                       new DepartureEntity("amfs", "14:29", "14:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "591", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "13:20", "13:20"),
                       new DepartureEntity("rta", "13:28", "13:28"),
                       new DepartureEntity("gd", "13:38", "13:43"),
                       new DepartureEntity("ut", "14:01", "14:06"),
                       new DepartureEntity("amf", "14:20", "14:25"),
                       new DepartureEntity("amfs", "14:29", "14:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "592", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "14:06", "14:06"),
                       new DepartureEntity("amf", "14:20", "14:20"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "593", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "13:23", "13:23"),
                       new DepartureEntity("gd", "13:40", "13:43"),
                       new DepartureEntity("ut", "14:01", "14:06"),
                       new DepartureEntity("amf", "14:20", "14:25"),
                       new DepartureEntity("amfs", "14:29", "14:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "594", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "13:20", "13:20"),
                       new DepartureEntity("gd", "13:37", "13:43"),
                       new DepartureEntity("ut", "14:01", "14:06"),
                       new DepartureEntity("amf", "14:20", "14:25"),
                       new DepartureEntity("amfs", "14:29", "14:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "595", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "13:23", "13:23"),
                       new DepartureEntity("gd", "13:40", "13:43"),
                       new DepartureEntity("ut", "14:01", "14:06"),
                       new DepartureEntity("amf", "14:20", "14:25"),
                       new DepartureEntity("amfs", "14:29", "14:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "596", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "13:24", "13:24"),
                       new DepartureEntity("gd", "13:41", "13:42"),
                       new DepartureEntity("ut", "14:01", "14:06"),
                       new DepartureEntity("amf", "14:20", "14:25"),
                       new DepartureEntity("amfs", "14:29", "14:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "597", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "13:23", "13:23"),
                       new DepartureEntity("gd", "13:40", "13:43"),
                       new DepartureEntity("ut", "14:01", "14:06"),
                       new DepartureEntity("amf", "14:20", "14:25"),
                       new DepartureEntity("amfs", "14:29", "14:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "598", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "13:23", "13:23"),
                       new DepartureEntity("gd", "13:43", "13:44"),
                       new DepartureEntity("ut", "14:02", "14:07"),
                       new DepartureEntity("amf", "14:20", "14:25"),
                       new DepartureEntity("amfs", "14:29", "14:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "599", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "13:20", "13:20"),
                       new DepartureEntity("gd", "13:37", "13:43"),
                       new DepartureEntity("ut", "14:01", "14:06"),
                       new DepartureEntity("amf", "14:20", "14:25"),
                       new DepartureEntity("amfs", "14:29", "14:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "600", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "14:06", "14:06"),
                       new DepartureEntity("amf", "14:20", "14:20"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "601", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "14:34", "14:34"),
                       new DepartureEntity("amf", "14:38", "14:40"),
                       new DepartureEntity("ut", "14:54", "14:59"),
                       new DepartureEntity("gd", "15:17", "15:22"),
                       new DepartureEntity("rta", "15:31", "15:31"),
                       new DepartureEntity("rtd", "15:40", "15:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "602", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "14:34", "14:34"),
                       new DepartureEntity("amf", "14:38", "14:40"),
                       new DepartureEntity("ut", "14:54", "14:59"),
                       new DepartureEntity("gd", "15:17", "15:22"),
                       new DepartureEntity("rta", "15:31", "15:31"),
                       new DepartureEntity("rtd", "15:40", "15:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "603", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "14:34", "14:34"),
                       new DepartureEntity("amf", "14:38", "14:40"),
                       new DepartureEntity("ut", "14:54", "14:59"),
                       new DepartureEntity("gd", "15:17", "15:22"),
                       new DepartureEntity("rta", "15:31", "15:31"),
                       new DepartureEntity("rtd", "15:40", "15:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "604", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "14:34", "14:34"),
                       new DepartureEntity("amf", "14:38", "14:40"),
                       new DepartureEntity("ut", "14:54", "14:59"),
                       new DepartureEntity("gd", "15:17", "15:22"),
                       new DepartureEntity("rta", "15:31", "15:31"),
                       new DepartureEntity("rtd", "15:40", "15:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "605", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "14:34", "14:34"),
                       new DepartureEntity("amf", "14:38", "14:40"),
                       new DepartureEntity("ut", "14:54", "15:02"),
                       new DepartureEntity("gd", "15:21", "15:22"),
                       new DepartureEntity("rta", "15:31", "15:31"),
                       new DepartureEntity("rtd", "15:40", "15:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "606", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "14:40", "14:40"),
                       new DepartureEntity("ut", "14:56", "14:56"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "607", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "14:34", "14:34"),
                       new DepartureEntity("amf", "14:38", "14:40"),
                       new DepartureEntity("ut", "14:54", "14:59"),
                       new DepartureEntity("gd", "15:19", "15:20"),
                       new DepartureEntity("gvc", "15:41", "15:41"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "608", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "14:34", "14:34"),
                       new DepartureEntity("amf", "14:38", "14:40"),
                       new DepartureEntity("ut", "14:54", "14:59"),
                       new DepartureEntity("gd", "15:18", "15:19"),
                       new DepartureEntity("gvc", "15:37", "15:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "609", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "14:34", "14:34"),
                       new DepartureEntity("amf", "14:38", "14:40"),
                       new DepartureEntity("ut", "14:54", "14:59"),
                       new DepartureEntity("gd", "15:17", "15:19"),
                       new DepartureEntity("gvc", "15:37", "15:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "610", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "14:40", "14:40"),
                       new DepartureEntity("ut", "14:56", "14:56"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "611", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "14:34", "14:34"),
                       new DepartureEntity("amf", "14:38", "14:40"),
                       new DepartureEntity("ut", "14:54", "14:59"),
                       new DepartureEntity("gd", "15:17", "15:19"),
                       new DepartureEntity("gvc", "15:37", "15:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "612", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "14:34", "14:34"),
                       new DepartureEntity("amf", "14:38", "14:40"),
                       new DepartureEntity("ut", "14:54", "14:59"),
                       new DepartureEntity("gd", "15:18", "15:19"),
                       new DepartureEntity("gvc", "15:37", "15:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "613", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "14:34", "14:34"),
                       new DepartureEntity("amf", "14:38", "14:40"),
                       new DepartureEntity("ut", "14:54", "14:59"),
                       new DepartureEntity("gd", "15:19", "15:20"),
                       new DepartureEntity("gvc", "15:41", "15:41"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "614", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "15:50", "15:50"),
                       new DepartureEntity("rta", "15:58", "15:58"),
                       new DepartureEntity("gd", "16:08", "16:09"),
                       new DepartureEntity("ut", "16:28", "16:36"),
                       new DepartureEntity("amf", "16:50", "16:53"),
                       new DepartureEntity("apd", "17:17", "17:18"),
                       new DepartureEntity("dv", "17:28", "17:30"),
                       new DepartureEntity("aml", "17:55", "17:56"),
                       new DepartureEntity("hgl", "18:07", "18:08"),
                       new DepartureEntity("es", "18:15", "18:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "615", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "15:50", "15:50"),
                       new DepartureEntity("rta", "15:58", "15:58"),
                       new DepartureEntity("gd", "16:08", "16:13"),
                       new DepartureEntity("ut", "16:31", "16:36"),
                       new DepartureEntity("amf", "16:50", "16:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "616", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "15:50", "15:50"),
                       new DepartureEntity("rta", "15:58", "15:58"),
                       new DepartureEntity("gd", "16:08", "16:13"),
                       new DepartureEntity("ut", "16:31", "16:36"),
                       new DepartureEntity("amf", "16:50", "16:53"),
                       new DepartureEntity("apd", "17:17", "17:18"),
                       new DepartureEntity("dv", "17:28", "17:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "617", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "15:50", "15:50"),
                       new DepartureEntity("rta", "15:58", "15:58"),
                       new DepartureEntity("gd", "16:08", "16:13"),
                       new DepartureEntity("ut", "16:31", "16:36"),
                       new DepartureEntity("amf", "16:50", "16:53"),
                       new DepartureEntity("apd", "17:17", "17:18"),
                       new DepartureEntity("dv", "17:28", "17:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "618", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "16:36", "16:36"),
                       new DepartureEntity("amf", "16:50", "16:53"),
                       new DepartureEntity("apd", "17:17", "17:18"),
                       new DepartureEntity("dv", "17:28", "17:30"),
                       new DepartureEntity("aml", "17:55", "17:56"),
                       new DepartureEntity("hgl", "18:07", "18:08"),
                       new DepartureEntity("es", "18:15", "18:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "619", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "15:50", "15:50"),
                       new DepartureEntity("gd", "16:07", "16:13"),
                       new DepartureEntity("ut", "16:31", "16:36"),
                       new DepartureEntity("amf", "16:50", "16:53"),
                       new DepartureEntity("apd", "17:17", "17:18"),
                       new DepartureEntity("dv", "17:28", "17:30"),
                       new DepartureEntity("aml", "17:55", "17:56"),
                       new DepartureEntity("hgl", "18:07", "18:08"),
                       new DepartureEntity("es", "18:15", "18:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "620", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "15:53", "15:53"),
                       new DepartureEntity("gd", "16:10", "16:13"),
                       new DepartureEntity("ut", "16:31", "16:36"),
                       new DepartureEntity("amf", "16:50", "16:53"),
                       new DepartureEntity("apd", "17:17", "17:18"),
                       new DepartureEntity("dv", "17:28", "17:30"),
                       new DepartureEntity("aml", "17:55", "17:56"),
                       new DepartureEntity("hgl", "18:07", "18:08"),
                       new DepartureEntity("es", "18:15", "18:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "621", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "15:54", "15:54"),
                       new DepartureEntity("gd", "16:11", "16:12"),
                       new DepartureEntity("ut", "16:31", "16:36"),
                       new DepartureEntity("amf", "16:50", "16:53"),
                       new DepartureEntity("apd", "17:17", "17:18"),
                       new DepartureEntity("dv", "17:28", "17:30"),
                       new DepartureEntity("aml", "17:55", "17:56"),
                       new DepartureEntity("hgl", "18:07", "18:08"),
                       new DepartureEntity("es", "18:15", "18:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "622", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "15:53", "15:53"),
                       new DepartureEntity("gd", "16:10", "16:13"),
                       new DepartureEntity("ut", "16:31", "16:36"),
                       new DepartureEntity("amf", "16:50", "16:53"),
                       new DepartureEntity("apd", "17:17", "17:18"),
                       new DepartureEntity("dv", "17:28", "17:30"),
                       new DepartureEntity("aml", "17:55", "17:56"),
                       new DepartureEntity("hgl", "18:07", "18:08"),
                       new DepartureEntity("es", "18:15", "18:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "623", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "15:50", "15:50"),
                       new DepartureEntity("gd", "16:07", "16:13"),
                       new DepartureEntity("ut", "16:31", "16:36"),
                       new DepartureEntity("amf", "16:50", "16:53"),
                       new DepartureEntity("apd", "17:17", "17:18"),
                       new DepartureEntity("dv", "17:28", "17:30"),
                       new DepartureEntity("aml", "17:55", "17:56"),
                       new DepartureEntity("hgl", "18:07", "18:08"),
                       new DepartureEntity("es", "18:15", "18:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "624", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "15:53", "15:53"),
                       new DepartureEntity("gd", "16:10", "16:13"),
                       new DepartureEntity("ut", "16:31", "16:36"),
                       new DepartureEntity("amf", "16:50", "16:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "625", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "06:10", "06:10"),
                       new DepartureEntity("ut", "06:24", "06:32"),
                       new DepartureEntity("gd", "06:51", "06:52"),
                       new DepartureEntity("rta", "07:01", "07:01"),
                       new DepartureEntity("rtd", "07:10", "07:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "626", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "04:46", "04:46"),
                       new DepartureEntity("hgl", "04:53", "04:54"),
                       new DepartureEntity("aml", "05:05", "05:06"),
                       new DepartureEntity("dv", "05:29", "05:32"),
                       new DepartureEntity("apd", "05:42", "05:43"),
                       new DepartureEntity("amf", "06:07", "06:10"),
                       new DepartureEntity("ut", "06:24", "06:29"),
                       new DepartureEntity("gd", "06:48", "06:49"),
                       new DepartureEntity("gvc", "07:07", "07:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "627", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "04:46", "04:46"),
                       new DepartureEntity("hgl", "04:53", "04:54"),
                       new DepartureEntity("aml", "05:05", "05:06"),
                       new DepartureEntity("dv", "05:29", "05:32"),
                       new DepartureEntity("apd", "05:42", "05:43"),
                       new DepartureEntity("amf", "06:07", "06:10"),
                       new DepartureEntity("ut", "06:24", "06:29"),
                       new DepartureEntity("gd", "06:48", "06:49"),
                       new DepartureEntity("gvc", "07:07", "07:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "628", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "04:46", "04:46"),
                       new DepartureEntity("hgl", "04:53", "04:54"),
                       new DepartureEntity("aml", "05:05", "05:06"),
                       new DepartureEntity("dv", "05:29", "05:32"),
                       new DepartureEntity("apd", "05:42", "05:43"),
                       new DepartureEntity("amf", "06:07", "06:10"),
                       new DepartureEntity("ut", "06:24", "06:29"),
                       new DepartureEntity("gd", "06:48", "06:49"),
                       new DepartureEntity("gvc", "07:07", "07:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "629", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "07:20", "07:20"),
                       new DepartureEntity("rta", "07:28", "07:28"),
                       new DepartureEntity("gd", "07:38", "07:39"),
                       new DepartureEntity("ut", "07:58", "08:06"),
                       new DepartureEntity("amf", "08:20", "08:25"),
                       new DepartureEntity("amfs", "08:29", "08:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "630", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "07:20", "07:20"),
                       new DepartureEntity("rta", "07:28", "07:28"),
                       new DepartureEntity("gd", "07:38", "07:43"),
                       new DepartureEntity("ut", "08:01", "08:06"),
                       new DepartureEntity("amf", "08:20", "08:25"),
                       new DepartureEntity("amfs", "08:29", "08:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "631", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "07:20", "07:20"),
                       new DepartureEntity("gd", "07:37", "07:43"),
                       new DepartureEntity("ut", "08:01", "08:06"),
                       new DepartureEntity("amf", "08:20", "08:25"),
                       new DepartureEntity("amfs", "08:29", "08:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "632", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "07:23", "07:23"),
                       new DepartureEntity("gd", "07:40", "07:43"),
                       new DepartureEntity("ut", "08:01", "08:06"),
                       new DepartureEntity("amf", "08:20", "08:25"),
                       new DepartureEntity("amfs", "08:29", "08:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "633", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "07:24", "07:24"),
                       new DepartureEntity("gd", "07:41", "07:42"),
                       new DepartureEntity("ut", "08:01", "08:06"),
                       new DepartureEntity("amf", "08:20", "08:25"),
                       new DepartureEntity("amfs", "08:29", "08:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "634", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "08:06", "08:06"),
                       new DepartureEntity("amf", "08:20", "08:20"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "635", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "08:34", "08:34"),
                       new DepartureEntity("amf", "08:38", "08:40"),
                       new DepartureEntity("ut", "08:54", "08:59"),
                       new DepartureEntity("gd", "09:17", "09:22"),
                       new DepartureEntity("rta", "09:31", "09:31"),
                       new DepartureEntity("rtd", "09:40", "09:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "636", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "08:34", "08:34"),
                       new DepartureEntity("amf", "08:38", "08:40"),
                       new DepartureEntity("ut", "08:54", "08:59"),
                       new DepartureEntity("gd", "09:17", "09:22"),
                       new DepartureEntity("rta", "09:31", "09:31"),
                       new DepartureEntity("rtd", "09:40", "09:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "637", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "08:34", "08:34"),
                       new DepartureEntity("amf", "08:38", "08:40"),
                       new DepartureEntity("ut", "08:54", "09:02"),
                       new DepartureEntity("gd", "09:21", "09:22"),
                       new DepartureEntity("rta", "09:31", "09:31"),
                       new DepartureEntity("rtd", "09:40", "09:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "638", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "08:34", "08:34"),
                       new DepartureEntity("amf", "08:38", "08:40"),
                       new DepartureEntity("ut", "08:54", "09:02"),
                       new DepartureEntity("gd", "09:21", "09:22"),
                       new DepartureEntity("rta", "09:31", "09:31"),
                       new DepartureEntity("rtd", "09:40", "09:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "639", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "08:40", "08:40"),
                       new DepartureEntity("ut", "08:56", "08:56"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "640", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "08:34", "08:34"),
                       new DepartureEntity("amf", "08:38", "08:40"),
                       new DepartureEntity("ut", "08:54", "08:59"),
                       new DepartureEntity("gd", "09:17", "09:19"),
                       new DepartureEntity("gvc", "09:37", "09:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "641", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "08:34", "08:34"),
                       new DepartureEntity("amf", "08:38", "08:40"),
                       new DepartureEntity("ut", "08:54", "08:59"),
                       new DepartureEntity("gd", "09:19", "09:20"),
                       new DepartureEntity("gvc", "09:41", "09:41"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "642", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "08:34", "08:34"),
                       new DepartureEntity("amf", "08:38", "08:40"),
                       new DepartureEntity("ut", "08:54", "08:59"),
                       new DepartureEntity("gd", "09:18", "09:19"),
                       new DepartureEntity("gvc", "09:37", "09:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "643", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "08:34", "08:34"),
                       new DepartureEntity("amf", "08:38", "08:40"),
                       new DepartureEntity("ut", "08:54", "08:59"),
                       new DepartureEntity("gd", "09:17", "09:19"),
                       new DepartureEntity("gvc", "09:37", "09:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "644", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "08:34", "08:34"),
                       new DepartureEntity("amf", "08:38", "08:40"),
                       new DepartureEntity("ut", "08:54", "08:59"),
                       new DepartureEntity("gd", "09:18", "09:19"),
                       new DepartureEntity("gvc", "09:37", "09:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "645", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "08:34", "08:34"),
                       new DepartureEntity("amf", "08:38", "08:40"),
                       new DepartureEntity("ut", "08:54", "08:59"),
                       new DepartureEntity("gd", "09:19", "09:20"),
                       new DepartureEntity("gvc", "09:41", "09:41"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "646", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "08:34", "08:34"),
                       new DepartureEntity("amf", "08:38", "08:40"),
                       new DepartureEntity("ut", "08:54", "08:59"),
                       new DepartureEntity("gd", "09:17", "09:19"),
                       new DepartureEntity("gvc", "09:40", "09:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "647", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "09:50", "09:50"),
                       new DepartureEntity("rta", "09:58", "09:58"),
                       new DepartureEntity("gd", "10:08", "10:09"),
                       new DepartureEntity("ut", "10:28", "10:36"),
                       new DepartureEntity("amf", "10:50", "10:53"),
                       new DepartureEntity("apd", "11:17", "11:18"),
                       new DepartureEntity("dv", "11:28", "11:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "648", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "09:50", "09:50"),
                       new DepartureEntity("rta", "09:58", "09:58"),
                       new DepartureEntity("gd", "10:08", "10:09"),
                       new DepartureEntity("ut", "10:28", "10:36"),
                       new DepartureEntity("amf", "10:50", "10:53"),
                       new DepartureEntity("apd", "11:17", "11:18"),
                       new DepartureEntity("dv", "11:28", "11:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "649", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "09:50", "09:50"),
                       new DepartureEntity("rta", "09:58", "09:58"),
                       new DepartureEntity("gd", "10:08", "10:13"),
                       new DepartureEntity("ut", "10:31", "10:36"),
                       new DepartureEntity("amf", "10:50", "10:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "650", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "09:50", "09:50"),
                       new DepartureEntity("rta", "09:58", "09:58"),
                       new DepartureEntity("gd", "10:08", "10:13"),
                       new DepartureEntity("ut", "10:31", "10:36"),
                       new DepartureEntity("amf", "10:50", "10:53"),
                       new DepartureEntity("apd", "11:17", "11:18"),
                       new DepartureEntity("dv", "11:28", "11:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "651", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "10:36", "10:36"),
                       new DepartureEntity("amf", "10:50", "10:53"),
                       new DepartureEntity("apd", "11:17", "11:18"),
                       new DepartureEntity("dv", "11:28", "11:30"),
                       new DepartureEntity("aml", "11:55", "11:56"),
                       new DepartureEntity("hgl", "12:07", "12:08"),
                       new DepartureEntity("es", "12:15", "12:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "652", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "09:53", "09:53"),
                       new DepartureEntity("gd", "10:10", "10:13"),
                       new DepartureEntity("ut", "10:31", "10:36"),
                       new DepartureEntity("amf", "10:50", "10:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "653", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "09:50", "09:50"),
                       new DepartureEntity("gd", "10:07", "10:13"),
                       new DepartureEntity("ut", "10:31", "10:36"),
                       new DepartureEntity("amf", "10:50", "10:53"),
                       new DepartureEntity("apd", "11:17", "11:18"),
                       new DepartureEntity("dv", "11:28", "11:30"),
                       new DepartureEntity("aml", "11:55", "11:56"),
                       new DepartureEntity("hgl", "12:07", "12:08"),
                       new DepartureEntity("es", "12:15", "12:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "654", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "09:53", "09:53"),
                       new DepartureEntity("gd", "10:10", "10:13"),
                       new DepartureEntity("ut", "10:31", "10:36"),
                       new DepartureEntity("amf", "10:50", "10:53"),
                       new DepartureEntity("apd", "11:17", "11:18"),
                       new DepartureEntity("dv", "11:28", "11:30"),
                       new DepartureEntity("aml", "11:55", "11:56"),
                       new DepartureEntity("hgl", "12:07", "12:08"),
                       new DepartureEntity("es", "12:15", "12:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "655", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "09:54", "09:54"),
                       new DepartureEntity("gd", "10:11", "10:12"),
                       new DepartureEntity("ut", "10:31", "10:36"),
                       new DepartureEntity("amf", "10:50", "10:53"),
                       new DepartureEntity("apd", "11:17", "11:18"),
                       new DepartureEntity("dv", "11:28", "11:30"),
                       new DepartureEntity("aml", "11:55", "11:56"),
                       new DepartureEntity("hgl", "12:07", "12:08"),
                       new DepartureEntity("es", "12:15", "12:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "656", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "09:53", "09:53"),
                       new DepartureEntity("gd", "10:10", "10:13"),
                       new DepartureEntity("ut", "10:31", "10:36"),
                       new DepartureEntity("amf", "10:50", "10:53"),
                       new DepartureEntity("apd", "11:17", "11:18"),
                       new DepartureEntity("dv", "11:28", "11:30"),
                       new DepartureEntity("aml", "11:55", "11:56"),
                       new DepartureEntity("hgl", "12:07", "12:08"),
                       new DepartureEntity("es", "12:15", "12:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "657", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "09:53", "09:53"),
                       new DepartureEntity("gd", "10:13", "10:14"),
                       new DepartureEntity("ut", "10:32", "10:37"),
                       new DepartureEntity("amf", "10:50", "10:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "658", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "09:50", "09:50"),
                       new DepartureEntity("gd", "10:07", "10:13"),
                       new DepartureEntity("ut", "10:31", "10:36"),
                       new DepartureEntity("amf", "10:50", "10:53"),
                       new DepartureEntity("apd", "11:17", "11:18"),
                       new DepartureEntity("dv", "11:28", "11:30"),
                       new DepartureEntity("aml", "11:55", "11:56"),
                       new DepartureEntity("hgl", "12:07", "12:08"),
                       new DepartureEntity("es", "12:15", "12:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "659", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "10:36", "10:36"),
                       new DepartureEntity("amf", "10:50", "10:53"),
                       new DepartureEntity("apd", "11:17", "11:18"),
                       new DepartureEntity("dv", "11:28", "11:30"),
                       new DepartureEntity("aml", "11:55", "11:56"),
                       new DepartureEntity("hgl", "12:07", "12:08"),
                       new DepartureEntity("es", "12:15", "12:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "660", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "13:10", "13:10"),
                       new DepartureEntity("ut", "13:24", "13:29"),
                       new DepartureEntity("gd", "13:47", "13:52"),
                       new DepartureEntity("rta", "14:01", "14:01"),
                       new DepartureEntity("rtd", "14:10", "14:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "661", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "13:10", "13:10"),
                       new DepartureEntity("ut", "13:24", "13:29"),
                       new DepartureEntity("gd", "13:47", "13:52"),
                       new DepartureEntity("rta", "14:01", "14:01"),
                       new DepartureEntity("rtd", "14:10", "14:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "662", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "12:32", "12:32"),
                       new DepartureEntity("apd", "12:42", "12:43"),
                       new DepartureEntity("amf", "13:07", "13:10"),
                       new DepartureEntity("ut", "13:24", "13:29"),
                       new DepartureEntity("gd", "13:47", "13:52"),
                       new DepartureEntity("rta", "14:01", "14:01"),
                       new DepartureEntity("rtd", "14:10", "14:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "663", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "12:32", "12:32"),
                       new DepartureEntity("apd", "12:42", "12:43"),
                       new DepartureEntity("amf", "13:07", "13:10"),
                       new DepartureEntity("ut", "13:24", "13:29"),
                       new DepartureEntity("gd", "13:47", "13:52"),
                       new DepartureEntity("rta", "14:01", "14:01"),
                       new DepartureEntity("rtd", "14:10", "14:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "664", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "12:32", "12:32"),
                       new DepartureEntity("apd", "12:42", "12:43"),
                       new DepartureEntity("amf", "13:07", "13:10"),
                       new DepartureEntity("ut", "13:24", "13:32"),
                       new DepartureEntity("gd", "13:51", "13:52"),
                       new DepartureEntity("rta", "14:01", "14:01"),
                       new DepartureEntity("rtd", "14:11", "14:11"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "665", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "12:32", "12:32"),
                       new DepartureEntity("apd", "12:42", "12:43"),
                       new DepartureEntity("amf", "13:07", "13:10"),
                       new DepartureEntity("ut", "13:24", "13:32"),
                       new DepartureEntity("gd", "13:51", "13:52"),
                       new DepartureEntity("rta", "14:01", "14:01"),
                       new DepartureEntity("rtd", "14:10", "14:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "666", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "13:10", "13:10"),
                       new DepartureEntity("ut", "13:24", "13:29"),
                       new DepartureEntity("gd", "13:47", "13:49"),
                       new DepartureEntity("gvc", "14:07", "14:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "667", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "11:46", "11:46"),
                       new DepartureEntity("hgl", "11:53", "11:54"),
                       new DepartureEntity("aml", "12:05", "12:06"),
                       new DepartureEntity("dv", "12:29", "12:32"),
                       new DepartureEntity("apd", "12:42", "12:43"),
                       new DepartureEntity("amf", "13:07", "13:10"),
                       new DepartureEntity("ut", "13:24", "13:29"),
                       new DepartureEntity("gd", "13:48", "13:49"),
                       new DepartureEntity("gvc", "14:07", "14:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "668", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "11:46", "11:46"),
                       new DepartureEntity("hgl", "11:53", "11:54"),
                       new DepartureEntity("aml", "12:05", "12:06"),
                       new DepartureEntity("dv", "12:29", "12:32"),
                       new DepartureEntity("apd", "12:42", "12:43"),
                       new DepartureEntity("amf", "13:07", "13:10"),
                       new DepartureEntity("ut", "13:24", "13:29"),
                       new DepartureEntity("gd", "13:47", "13:49"),
                       new DepartureEntity("gvc", "14:07", "14:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "669", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "11:46", "11:46"),
                       new DepartureEntity("hgl", "11:53", "11:54"),
                       new DepartureEntity("aml", "12:05", "12:06"),
                       new DepartureEntity("dv", "12:29", "12:32"),
                       new DepartureEntity("apd", "12:42", "12:43"),
                       new DepartureEntity("amf", "13:07", "13:10"),
                       new DepartureEntity("ut", "13:26", "13:26"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "670", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "11:46", "11:46"),
                       new DepartureEntity("hgl", "11:53", "11:54"),
                       new DepartureEntity("aml", "12:05", "12:06"),
                       new DepartureEntity("dv", "12:29", "12:32"),
                       new DepartureEntity("apd", "12:42", "12:43"),
                       new DepartureEntity("amf", "13:07", "13:10"),
                       new DepartureEntity("ut", "13:24", "13:29"),
                       new DepartureEntity("gd", "13:49", "13:50"),
                       new DepartureEntity("gvc", "14:11", "14:11"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "671", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "13:10", "13:10"),
                       new DepartureEntity("ut", "13:24", "13:29"),
                       new DepartureEntity("gd", "13:47", "13:49"),
                       new DepartureEntity("gvc", "14:10", "14:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "672", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "11:46", "11:46"),
                       new DepartureEntity("hgl", "11:53", "11:54"),
                       new DepartureEntity("aml", "12:05", "12:06"),
                       new DepartureEntity("dv", "12:29", "12:32"),
                       new DepartureEntity("apd", "12:42", "12:43"),
                       new DepartureEntity("amf", "13:07", "13:10"),
                       new DepartureEntity("ut", "13:24", "13:29"),
                       new DepartureEntity("gd", "13:48", "13:49"),
                       new DepartureEntity("gvc", "14:07", "14:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "673", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "11:46", "11:46"),
                       new DepartureEntity("hgl", "11:53", "11:54"),
                       new DepartureEntity("aml", "12:05", "12:06"),
                       new DepartureEntity("dv", "12:29", "12:32"),
                       new DepartureEntity("apd", "12:42", "12:43"),
                       new DepartureEntity("amf", "13:07", "13:10"),
                       new DepartureEntity("ut", "13:24", "13:29"),
                       new DepartureEntity("gd", "13:49", "13:50"),
                       new DepartureEntity("gvc", "14:11", "14:11"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "674", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "11:46", "11:46"),
                       new DepartureEntity("hgl", "11:53", "11:54"),
                       new DepartureEntity("aml", "12:05", "12:06"),
                       new DepartureEntity("dv", "12:29", "12:32"),
                       new DepartureEntity("apd", "12:42", "12:43"),
                       new DepartureEntity("amf", "13:07", "13:10"),
                       new DepartureEntity("ut", "13:24", "13:29"),
                       new DepartureEntity("gd", "13:48", "13:49"),
                       new DepartureEntity("gvc", "14:07", "14:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "675", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "11:46", "11:46"),
                       new DepartureEntity("hgl", "11:53", "11:54"),
                       new DepartureEntity("aml", "12:05", "12:06"),
                       new DepartureEntity("dv", "12:29", "12:32"),
                       new DepartureEntity("apd", "12:42", "12:43"),
                       new DepartureEntity("amf", "13:07", "13:10"),
                       new DepartureEntity("ut", "13:24", "13:29"),
                       new DepartureEntity("gd", "13:48", "13:49"),
                       new DepartureEntity("gvc", "14:07", "14:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "676", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "14:20", "14:20"),
                       new DepartureEntity("rta", "14:28", "14:28"),
                       new DepartureEntity("gd", "14:38", "14:39"),
                       new DepartureEntity("ut", "14:58", "15:06"),
                       new DepartureEntity("amf", "15:20", "15:25"),
                       new DepartureEntity("amfs", "15:29", "15:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "677", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "14:20", "14:20"),
                       new DepartureEntity("rta", "14:28", "14:28"),
                       new DepartureEntity("gd", "14:38", "14:39"),
                       new DepartureEntity("ut", "14:58", "15:06"),
                       new DepartureEntity("amf", "15:20", "15:25"),
                       new DepartureEntity("amfs", "15:29", "15:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "678", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "14:20", "14:20"),
                       new DepartureEntity("rta", "14:28", "14:28"),
                       new DepartureEntity("gd", "14:38", "14:43"),
                       new DepartureEntity("ut", "15:01", "15:06"),
                       new DepartureEntity("amf", "15:20", "15:25"),
                       new DepartureEntity("amfs", "15:29", "15:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "679", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "14:20", "14:20"),
                       new DepartureEntity("rta", "14:28", "14:28"),
                       new DepartureEntity("gd", "14:38", "14:44"),
                       new DepartureEntity("ut", "15:01", "15:06"),
                       new DepartureEntity("amf", "15:20", "15:25"),
                       new DepartureEntity("amfs", "15:29", "15:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "680", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "14:20", "14:20"),
                       new DepartureEntity("rta", "14:28", "14:28"),
                       new DepartureEntity("gd", "14:38", "14:43"),
                       new DepartureEntity("ut", "15:01", "15:06"),
                       new DepartureEntity("amf", "15:20", "15:25"),
                       new DepartureEntity("amfs", "15:29", "15:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "681", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "15:06", "15:06"),
                       new DepartureEntity("amf", "15:20", "15:20"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "682", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "14:23", "14:23"),
                       new DepartureEntity("gd", "14:40", "14:43"),
                       new DepartureEntity("ut", "15:01", "15:06"),
                       new DepartureEntity("amf", "15:20", "15:25"),
                       new DepartureEntity("amfs", "15:29", "15:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "683", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "14:20", "14:20"),
                       new DepartureEntity("gd", "14:37", "14:43"),
                       new DepartureEntity("ut", "15:01", "15:06"),
                       new DepartureEntity("amf", "15:20", "15:25"),
                       new DepartureEntity("amfs", "15:29", "15:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "684", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "14:23", "14:23"),
                       new DepartureEntity("gd", "14:40", "14:43"),
                       new DepartureEntity("ut", "15:01", "15:06"),
                       new DepartureEntity("amf", "15:20", "15:25"),
                       new DepartureEntity("amfs", "15:29", "15:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "685", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "14:24", "14:24"),
                       new DepartureEntity("gd", "14:41", "14:42"),
                       new DepartureEntity("ut", "15:01", "15:06"),
                       new DepartureEntity("amf", "15:20", "15:25"),
                       new DepartureEntity("amfs", "15:29", "15:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "686", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "14:24", "14:24"),
                       new DepartureEntity("gd", "14:41", "14:42"),
                       new DepartureEntity("ut", "15:01", "15:06"),
                       new DepartureEntity("amf", "15:20", "15:25"),
                       new DepartureEntity("amfs", "15:29", "15:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "687", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "14:23", "14:23"),
                       new DepartureEntity("gd", "14:43", "14:44"),
                       new DepartureEntity("ut", "15:01", "15:06"),
                       new DepartureEntity("amf", "15:20", "15:25"),
                       new DepartureEntity("amfs", "15:29", "15:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "688", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "14:20", "14:20"),
                       new DepartureEntity("gd", "14:37", "14:43"),
                       new DepartureEntity("ut", "15:01", "15:06"),
                       new DepartureEntity("amf", "15:20", "15:25"),
                       new DepartureEntity("amfs", "15:29", "15:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "689", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "15:06", "15:06"),
                       new DepartureEntity("amf", "15:20", "15:20"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "690", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "15:34", "15:34"),
                       new DepartureEntity("amf", "15:38", "15:40"),
                       new DepartureEntity("ut", "15:54", "15:59"),
                       new DepartureEntity("gd", "16:17", "16:22"),
                       new DepartureEntity("rta", "16:31", "16:31"),
                       new DepartureEntity("rtd", "16:40", "16:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "691", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "15:34", "15:34"),
                       new DepartureEntity("amf", "15:38", "15:40"),
                       new DepartureEntity("ut", "15:54", "15:59"),
                       new DepartureEntity("gd", "16:17", "16:22"),
                       new DepartureEntity("rta", "16:31", "16:31"),
                       new DepartureEntity("rtd", "16:40", "16:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "692", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "15:34", "15:34"),
                       new DepartureEntity("amf", "15:38", "15:40"),
                       new DepartureEntity("ut", "15:54", "15:59"),
                       new DepartureEntity("gd", "16:17", "16:22"),
                       new DepartureEntity("rta", "16:31", "16:31"),
                       new DepartureEntity("rtd", "16:40", "16:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "693", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "15:34", "15:34"),
                       new DepartureEntity("amf", "15:38", "15:40"),
                       new DepartureEntity("ut", "15:54", "15:59"),
                       new DepartureEntity("gd", "16:17", "16:22"),
                       new DepartureEntity("rta", "16:31", "16:31"),
                       new DepartureEntity("rtd", "16:40", "16:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "694", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "15:34", "15:34"),
                       new DepartureEntity("amf", "15:38", "15:40"),
                       new DepartureEntity("ut", "15:54", "16:02"),
                       new DepartureEntity("gd", "16:21", "16:22"),
                       new DepartureEntity("rta", "16:31", "16:31"),
                       new DepartureEntity("rtd", "16:40", "16:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "695", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "15:40", "15:40"),
                       new DepartureEntity("ut", "15:56", "15:56"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "696", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "15:34", "15:34"),
                       new DepartureEntity("amf", "15:38", "15:40"),
                       new DepartureEntity("ut", "15:54", "15:59"),
                       new DepartureEntity("gd", "16:17", "16:19"),
                       new DepartureEntity("gvc", "16:37", "16:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "697", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "15:34", "15:34"),
                       new DepartureEntity("amf", "15:38", "15:40"),
                       new DepartureEntity("ut", "15:54", "15:59"),
                       new DepartureEntity("gd", "16:18", "16:19"),
                       new DepartureEntity("gvc", "16:37", "16:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "698", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "15:34", "15:34"),
                       new DepartureEntity("amf", "15:38", "15:40"),
                       new DepartureEntity("ut", "15:54", "15:59"),
                       new DepartureEntity("gd", "16:17", "16:19"),
                       new DepartureEntity("gvc", "16:37", "16:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "699", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "15:40", "15:40"),
                       new DepartureEntity("ut", "15:56", "15:56"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "700", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "15:34", "15:34"),
                       new DepartureEntity("amf", "15:38", "15:40"),
                       new DepartureEntity("ut", "15:54", "15:59"),
                       new DepartureEntity("gd", "16:17", "16:19"),
                       new DepartureEntity("gvc", "16:37", "16:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "701", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "15:34", "15:34"),
                       new DepartureEntity("amf", "15:38", "15:40"),
                       new DepartureEntity("ut", "15:54", "15:59"),
                       new DepartureEntity("gd", "16:18", "16:19"),
                       new DepartureEntity("gvc", "16:37", "16:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "702", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "15:34", "15:34"),
                       new DepartureEntity("amf", "15:38", "15:40"),
                       new DepartureEntity("ut", "15:54", "15:59"),
                       new DepartureEntity("gd", "16:19", "16:20"),
                       new DepartureEntity("gvc", "16:41", "16:41"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "703", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "15:34", "15:34"),
                       new DepartureEntity("amf", "15:38", "15:40"),
                       new DepartureEntity("ut", "15:54", "15:59"),
                       new DepartureEntity("gd", "16:19", "16:20"),
                       new DepartureEntity("gvc", "16:41", "16:41"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "704", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "16:50", "16:50"),
                       new DepartureEntity("rta", "16:58", "16:58"),
                       new DepartureEntity("gd", "17:08", "17:09"),
                       new DepartureEntity("ut", "17:28", "17:36"),
                       new DepartureEntity("amf", "17:50", "17:53"),
                       new DepartureEntity("apd", "18:17", "18:18"),
                       new DepartureEntity("dv", "18:28", "18:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "705", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "16:50", "16:50"),
                       new DepartureEntity("rta", "16:58", "16:58"),
                       new DepartureEntity("gd", "17:08", "17:13"),
                       new DepartureEntity("ut", "17:31", "17:36"),
                       new DepartureEntity("amf", "17:50", "17:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "706", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "16:50", "16:50"),
                       new DepartureEntity("rta", "16:58", "16:58"),
                       new DepartureEntity("gd", "17:08", "17:13"),
                       new DepartureEntity("ut", "17:31", "17:36"),
                       new DepartureEntity("amf", "17:50", "17:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "707", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "16:50", "16:50"),
                       new DepartureEntity("rta", "16:58", "16:58"),
                       new DepartureEntity("gd", "17:08", "17:13"),
                       new DepartureEntity("ut", "17:31", "17:36"),
                       new DepartureEntity("amf", "17:50", "17:53"),
                       new DepartureEntity("apd", "18:17", "18:18"),
                       new DepartureEntity("dv", "18:28", "18:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "708", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "17:36", "17:36"),
                       new DepartureEntity("amf", "17:50", "17:53"),
                       new DepartureEntity("apd", "18:17", "18:18"),
                       new DepartureEntity("dv", "18:28", "18:30"),
                       new DepartureEntity("aml", "18:55", "18:56"),
                       new DepartureEntity("hgl", "19:07", "19:08"),
                       new DepartureEntity("es", "19:15", "19:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "709", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "16:50", "16:50"),
                       new DepartureEntity("gd", "17:07", "17:13"),
                       new DepartureEntity("ut", "17:31", "17:36"),
                       new DepartureEntity("amf", "17:50", "17:53"),
                       new DepartureEntity("apd", "18:17", "18:18"),
                       new DepartureEntity("dv", "18:28", "18:30"),
                       new DepartureEntity("aml", "18:55", "18:56"),
                       new DepartureEntity("hgl", "19:07", "19:08"),
                       new DepartureEntity("es", "19:15", "19:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "710", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "16:53", "16:53"),
                       new DepartureEntity("gd", "17:10", "17:13"),
                       new DepartureEntity("ut", "17:31", "17:36"),
                       new DepartureEntity("amf", "17:50", "17:53"),
                       new DepartureEntity("apd", "18:17", "18:18"),
                       new DepartureEntity("dv", "18:28", "18:30"),
                       new DepartureEntity("aml", "18:55", "18:56"),
                       new DepartureEntity("hgl", "19:07", "19:08"),
                       new DepartureEntity("es", "19:15", "19:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "711", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "16:54", "16:54"),
                       new DepartureEntity("gd", "17:11", "17:12"),
                       new DepartureEntity("ut", "17:31", "17:36"),
                       new DepartureEntity("amf", "17:50", "17:53"),
                       new DepartureEntity("apd", "18:17", "18:18"),
                       new DepartureEntity("dv", "18:28", "18:30"),
                       new DepartureEntity("aml", "18:55", "18:56"),
                       new DepartureEntity("hgl", "19:07", "19:08"),
                       new DepartureEntity("es", "19:15", "19:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "712", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "16:53", "16:53"),
                       new DepartureEntity("gd", "17:10", "17:13"),
                       new DepartureEntity("ut", "17:31", "17:36"),
                       new DepartureEntity("amf", "17:50", "17:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "713", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "16:50", "16:50"),
                       new DepartureEntity("gd", "17:07", "17:13"),
                       new DepartureEntity("ut", "17:31", "17:36"),
                       new DepartureEntity("amf", "17:50", "17:53"),
                       new DepartureEntity("apd", "18:17", "18:18"),
                       new DepartureEntity("dv", "18:28", "18:30"),
                       new DepartureEntity("aml", "18:55", "18:56"),
                       new DepartureEntity("hgl", "19:07", "19:08"),
                       new DepartureEntity("es", "19:15", "19:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "714", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "20:10", "20:10"),
                       new DepartureEntity("ut", "20:24", "20:29"),
                       new DepartureEntity("gd", "20:47", "20:52"),
                       new DepartureEntity("rta", "21:01", "21:01"),
                       new DepartureEntity("rtd", "21:10", "21:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "715", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "19:32", "19:32"),
                       new DepartureEntity("apd", "19:42", "19:43"),
                       new DepartureEntity("amf", "20:07", "20:10"),
                       new DepartureEntity("ut", "20:24", "20:29"),
                       new DepartureEntity("gd", "20:47", "20:52"),
                       new DepartureEntity("rta", "21:01", "21:01"),
                       new DepartureEntity("rtd", "21:10", "21:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "716", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "19:32", "19:32"),
                       new DepartureEntity("apd", "19:42", "19:43"),
                       new DepartureEntity("amf", "20:07", "20:10"),
                       new DepartureEntity("ut", "20:24", "20:29"),
                       new DepartureEntity("gd", "20:47", "20:52"),
                       new DepartureEntity("rta", "21:01", "21:01"),
                       new DepartureEntity("rtd", "21:10", "21:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "717", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "19:32", "19:32"),
                       new DepartureEntity("apd", "19:42", "19:43"),
                       new DepartureEntity("amf", "20:07", "20:10"),
                       new DepartureEntity("ut", "20:24", "20:29"),
                       new DepartureEntity("gd", "20:47", "20:52"),
                       new DepartureEntity("rta", "21:01", "21:01"),
                       new DepartureEntity("rtd", "21:10", "21:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "718", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "19:32", "19:32"),
                       new DepartureEntity("apd", "19:42", "19:43"),
                       new DepartureEntity("amf", "20:07", "20:10"),
                       new DepartureEntity("ut", "20:24", "20:32"),
                       new DepartureEntity("gd", "20:51", "20:52"),
                       new DepartureEntity("rta", "21:01", "21:01"),
                       new DepartureEntity("rtd", "21:10", "21:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "719", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "20:10", "20:10"),
                       new DepartureEntity("ut", "20:24", "20:29"),
                       new DepartureEntity("gd", "20:47", "20:49"),
                       new DepartureEntity("gvc", "21:07", "21:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "720", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "18:46", "18:46"),
                       new DepartureEntity("hgl", "18:53", "18:54"),
                       new DepartureEntity("aml", "19:05", "19:06"),
                       new DepartureEntity("dv", "19:29", "19:32"),
                       new DepartureEntity("apd", "19:42", "19:43"),
                       new DepartureEntity("amf", "20:07", "20:10"),
                       new DepartureEntity("ut", "20:24", "20:29"),
                       new DepartureEntity("gd", "20:48", "20:49"),
                       new DepartureEntity("gvc", "21:07", "21:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "721", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "18:46", "18:46"),
                       new DepartureEntity("hgl", "18:53", "18:54"),
                       new DepartureEntity("aml", "19:05", "19:06"),
                       new DepartureEntity("dv", "19:29", "19:32"),
                       new DepartureEntity("apd", "19:42", "19:43"),
                       new DepartureEntity("amf", "20:07", "20:10"),
                       new DepartureEntity("ut", "20:24", "20:29"),
                       new DepartureEntity("gd", "20:47", "20:49"),
                       new DepartureEntity("gvc", "21:07", "21:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "722", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "18:46", "18:46"),
                       new DepartureEntity("hgl", "18:53", "18:54"),
                       new DepartureEntity("aml", "19:05", "19:06"),
                       new DepartureEntity("dv", "19:29", "19:32"),
                       new DepartureEntity("apd", "19:42", "19:43"),
                       new DepartureEntity("amf", "20:07", "20:10"),
                       new DepartureEntity("ut", "20:26", "20:26"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "723", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "18:46", "18:46"),
                       new DepartureEntity("hgl", "18:53", "18:54"),
                       new DepartureEntity("aml", "19:05", "19:06"),
                       new DepartureEntity("dv", "19:29", "19:32"),
                       new DepartureEntity("apd", "19:42", "19:43"),
                       new DepartureEntity("amf", "20:07", "20:10"),
                       new DepartureEntity("ut", "20:24", "20:29"),
                       new DepartureEntity("gd", "20:49", "20:50"),
                       new DepartureEntity("gvc", "21:11", "21:11"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "724", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "18:46", "18:46"),
                       new DepartureEntity("hgl", "18:53", "18:54"),
                       new DepartureEntity("aml", "19:05", "19:06"),
                       new DepartureEntity("dv", "19:29", "19:32"),
                       new DepartureEntity("apd", "19:42", "19:43"),
                       new DepartureEntity("amf", "20:07", "20:10"),
                       new DepartureEntity("ut", "20:26", "20:26"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "725", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "18:46", "18:46"),
                       new DepartureEntity("hgl", "18:53", "18:54"),
                       new DepartureEntity("aml", "19:05", "19:06"),
                       new DepartureEntity("dv", "19:29", "19:32"),
                       new DepartureEntity("apd", "19:42", "19:43"),
                       new DepartureEntity("amf", "20:07", "20:10"),
                       new DepartureEntity("ut", "20:24", "20:29"),
                       new DepartureEntity("gd", "20:47", "20:49"),
                       new DepartureEntity("gvc", "21:07", "21:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "726", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "18:46", "18:46"),
                       new DepartureEntity("hgl", "18:53", "18:54"),
                       new DepartureEntity("aml", "19:05", "19:06"),
                       new DepartureEntity("dv", "19:29", "19:32"),
                       new DepartureEntity("apd", "19:42", "19:43"),
                       new DepartureEntity("amf", "20:07", "20:10"),
                       new DepartureEntity("ut", "20:24", "20:29"),
                       new DepartureEntity("gd", "20:48", "20:49"),
                       new DepartureEntity("gvc", "21:07", "21:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "727", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "18:46", "18:46"),
                       new DepartureEntity("hgl", "18:53", "18:54"),
                       new DepartureEntity("aml", "19:05", "19:06"),
                       new DepartureEntity("dv", "19:29", "19:32"),
                       new DepartureEntity("apd", "19:42", "19:43"),
                       new DepartureEntity("amf", "20:07", "20:10"),
                       new DepartureEntity("ut", "20:24", "20:29"),
                       new DepartureEntity("gd", "20:49", "20:50"),
                       new DepartureEntity("gvc", "21:11", "21:11"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "728", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "18:46", "18:46"),
                       new DepartureEntity("hgl", "18:53", "18:54"),
                       new DepartureEntity("aml", "19:05", "19:06"),
                       new DepartureEntity("dv", "19:29", "19:32"),
                       new DepartureEntity("apd", "19:42", "19:43"),
                       new DepartureEntity("amf", "20:07", "20:10"),
                       new DepartureEntity("ut", "20:24", "20:29"),
                       new DepartureEntity("gd", "20:48", "20:49"),
                       new DepartureEntity("gvc", "21:07", "21:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "729", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "18:46", "18:46"),
                       new DepartureEntity("hgl", "18:53", "18:54"),
                       new DepartureEntity("aml", "19:05", "19:06"),
                       new DepartureEntity("dv", "19:29", "19:32"),
                       new DepartureEntity("apd", "19:42", "19:43"),
                       new DepartureEntity("amf", "20:07", "20:10"),
                       new DepartureEntity("ut", "20:24", "20:29"),
                       new DepartureEntity("gd", "20:48", "20:49"),
                       new DepartureEntity("gvc", "21:07", "21:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "730", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "17:10", "17:10"),
                       new DepartureEntity("ut", "17:24", "17:29"),
                       new DepartureEntity("gd", "17:47", "17:52"),
                       new DepartureEntity("rta", "18:01", "18:01"),
                       new DepartureEntity("rtd", "18:10", "18:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "731", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "16:32", "16:32"),
                       new DepartureEntity("apd", "16:42", "16:43"),
                       new DepartureEntity("amf", "17:07", "17:10"),
                       new DepartureEntity("ut", "17:24", "17:29"),
                       new DepartureEntity("gd", "17:47", "17:52"),
                       new DepartureEntity("rta", "18:01", "18:01"),
                       new DepartureEntity("rtd", "18:10", "18:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "732", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "16:32", "16:32"),
                       new DepartureEntity("apd", "16:42", "16:43"),
                       new DepartureEntity("amf", "17:07", "17:10"),
                       new DepartureEntity("ut", "17:24", "17:29"),
                       new DepartureEntity("gd", "17:47", "17:52"),
                       new DepartureEntity("rta", "18:01", "18:01"),
                       new DepartureEntity("rtd", "18:10", "18:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "733", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dv", "16:32", "16:32"),
                       new DepartureEntity("apd", "16:42", "16:43"),
                       new DepartureEntity("amf", "17:07", "17:10"),
                       new DepartureEntity("ut", "17:24", "17:32"),
                       new DepartureEntity("gd", "17:51", "17:52"),
                       new DepartureEntity("rta", "18:01", "18:01"),
                       new DepartureEntity("rtd", "18:10", "18:10"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "734", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "17:10", "17:10"),
                       new DepartureEntity("ut", "17:24", "17:29"),
                       new DepartureEntity("gd", "17:47", "17:49"),
                       new DepartureEntity("gvc", "18:07", "18:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "735", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "15:46", "15:46"),
                       new DepartureEntity("hgl", "15:53", "15:54"),
                       new DepartureEntity("aml", "16:05", "16:06"),
                       new DepartureEntity("dv", "16:29", "16:32"),
                       new DepartureEntity("apd", "16:42", "16:43"),
                       new DepartureEntity("amf", "17:07", "17:10"),
                       new DepartureEntity("ut", "17:24", "17:29"),
                       new DepartureEntity("gd", "17:47", "17:49"),
                       new DepartureEntity("gvc", "18:07", "18:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "736", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "15:46", "15:46"),
                       new DepartureEntity("hgl", "15:53", "15:54"),
                       new DepartureEntity("aml", "16:05", "16:06"),
                       new DepartureEntity("dv", "16:29", "16:32"),
                       new DepartureEntity("apd", "16:42", "16:43"),
                       new DepartureEntity("amf", "17:07", "17:10"),
                       new DepartureEntity("ut", "17:26", "17:26"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "737", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "15:46", "15:46"),
                       new DepartureEntity("hgl", "15:53", "15:54"),
                       new DepartureEntity("aml", "16:05", "16:06"),
                       new DepartureEntity("dv", "16:29", "16:32"),
                       new DepartureEntity("apd", "16:42", "16:43"),
                       new DepartureEntity("amf", "17:07", "17:10"),
                       new DepartureEntity("ut", "17:24", "17:29"),
                       new DepartureEntity("gd", "17:48", "17:49"),
                       new DepartureEntity("gvc", "18:07", "18:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "738", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "15:46", "15:46"),
                       new DepartureEntity("hgl", "15:53", "15:54"),
                       new DepartureEntity("aml", "16:05", "16:06"),
                       new DepartureEntity("dv", "16:29", "16:32"),
                       new DepartureEntity("apd", "16:42", "16:43"),
                       new DepartureEntity("amf", "17:07", "17:10"),
                       new DepartureEntity("ut", "17:24", "17:29"),
                       new DepartureEntity("gd", "17:48", "17:49"),
                       new DepartureEntity("gvc", "18:07", "18:07"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "739", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("es", "15:46", "15:46"),
                       new DepartureEntity("hgl", "15:53", "15:54"),
                       new DepartureEntity("aml", "16:05", "16:06"),
                       new DepartureEntity("dv", "16:29", "16:32"),
                       new DepartureEntity("apd", "16:42", "16:43"),
                       new DepartureEntity("amf", "17:07", "17:10"),
                       new DepartureEntity("ut", "17:24", "17:29"),
                       new DepartureEntity("gd", "17:49", "17:50"),
                       new DepartureEntity("gvc", "18:11", "18:11"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "740", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "18:20", "18:20"),
                       new DepartureEntity("rta", "18:28", "18:28"),
                       new DepartureEntity("gd", "18:38", "18:39"),
                       new DepartureEntity("ut", "18:58", "19:06"),
                       new DepartureEntity("amf", "19:20", "19:25"),
                       new DepartureEntity("amfs", "19:29", "19:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "741", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "18:20", "18:20"),
                       new DepartureEntity("rta", "18:28", "18:28"),
                       new DepartureEntity("gd", "18:38", "18:43"),
                       new DepartureEntity("ut", "19:01", "19:06"),
                       new DepartureEntity("amf", "19:20", "19:25"),
                       new DepartureEntity("amfs", "19:29", "19:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "742", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "19:06", "19:06"),
                       new DepartureEntity("amf", "19:20", "19:20"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "743", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "18:20", "18:20"),
                       new DepartureEntity("gd", "18:37", "18:43"),
                       new DepartureEntity("ut", "19:01", "19:06"),
                       new DepartureEntity("amf", "19:20", "19:25"),
                       new DepartureEntity("amfs", "19:29", "19:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "744", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "18:23", "18:23"),
                       new DepartureEntity("gd", "18:40", "18:43"),
                       new DepartureEntity("ut", "19:01", "19:06"),
                       new DepartureEntity("amf", "19:20", "19:25"),
                       new DepartureEntity("amfs", "19:29", "19:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "745", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "18:24", "18:24"),
                       new DepartureEntity("gd", "18:41", "18:42"),
                       new DepartureEntity("ut", "19:01", "19:06"),
                       new DepartureEntity("amf", "19:20", "19:25"),
                       new DepartureEntity("amfs", "19:29", "19:29"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "746", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "19:06", "19:06"),
                       new DepartureEntity("amf", "19:20", "19:20"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "747", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "19:34", "19:34"),
                       new DepartureEntity("amf", "19:38", "19:40"),
                       new DepartureEntity("ut", "19:54", "19:59"),
                       new DepartureEntity("gd", "20:17", "20:22"),
                       new DepartureEntity("rta", "20:31", "20:31"),
                       new DepartureEntity("rtd", "20:40", "20:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "748", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "19:34", "19:34"),
                       new DepartureEntity("amf", "19:38", "19:40"),
                       new DepartureEntity("ut", "19:54", "19:59"),
                       new DepartureEntity("gd", "20:17", "20:22"),
                       new DepartureEntity("rta", "20:31", "20:31"),
                       new DepartureEntity("rtd", "20:40", "20:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "749", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "19:34", "19:34"),
                       new DepartureEntity("amf", "19:38", "19:40"),
                       new DepartureEntity("ut", "19:54", "20:02"),
                       new DepartureEntity("gd", "20:21", "20:22"),
                       new DepartureEntity("rta", "20:31", "20:31"),
                       new DepartureEntity("rtd", "20:40", "20:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "750", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "19:40", "19:40"),
                       new DepartureEntity("ut", "19:56", "19:56"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "751", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "19:34", "19:34"),
                       new DepartureEntity("amf", "19:38", "19:40"),
                       new DepartureEntity("ut", "19:54", "19:59"),
                       new DepartureEntity("gd", "20:18", "20:19"),
                       new DepartureEntity("gvc", "20:37", "20:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "752", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "19:34", "19:34"),
                       new DepartureEntity("amf", "19:38", "19:40"),
                       new DepartureEntity("ut", "19:54", "19:59"),
                       new DepartureEntity("gd", "20:17", "20:19"),
                       new DepartureEntity("gvc", "20:37", "20:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "753", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amf", "19:40", "19:40"),
                       new DepartureEntity("ut", "19:56", "19:56"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "754", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "19:34", "19:34"),
                       new DepartureEntity("amf", "19:38", "19:40"),
                       new DepartureEntity("ut", "19:54", "19:59"),
                       new DepartureEntity("gd", "20:18", "20:19"),
                       new DepartureEntity("gvc", "20:37", "20:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "755", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "19:34", "19:34"),
                       new DepartureEntity("amf", "19:38", "19:40"),
                       new DepartureEntity("ut", "19:54", "19:59"),
                       new DepartureEntity("gd", "20:19", "20:20"),
                       new DepartureEntity("gvc", "20:41", "20:41"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "756", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "19:34", "19:34"),
                       new DepartureEntity("amf", "19:38", "19:40"),
                       new DepartureEntity("ut", "19:54", "19:59"),
                       new DepartureEntity("gd", "20:18", "20:19"),
                       new DepartureEntity("gvc", "20:37", "20:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "757", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("amfs", "19:34", "19:34"),
                       new DepartureEntity("amf", "19:38", "19:40"),
                       new DepartureEntity("ut", "19:54", "19:59"),
                       new DepartureEntity("gd", "20:18", "20:19"),
                       new DepartureEntity("gvc", "20:37", "20:37"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "758", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "20:50", "20:50"),
                       new DepartureEntity("rta", "20:58", "20:58"),
                       new DepartureEntity("gd", "21:08", "21:09"),
                       new DepartureEntity("ut", "21:28", "21:36"),
                       new DepartureEntity("amf", "21:50", "21:53"),
                       new DepartureEntity("apd", "22:17", "22:18"),
                       new DepartureEntity("dv", "22:28", "22:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "759", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "20:50", "20:50"),
                       new DepartureEntity("rta", "20:58", "20:58"),
                       new DepartureEntity("gd", "21:08", "21:09"),
                       new DepartureEntity("ut", "21:28", "21:36"),
                       new DepartureEntity("amf", "21:50", "21:53"),
                       new DepartureEntity("apd", "22:17", "22:18"),
                       new DepartureEntity("dv", "22:28", "22:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "760", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "20:50", "20:50"),
                       new DepartureEntity("rta", "20:58", "20:58"),
                       new DepartureEntity("gd", "21:08", "21:13"),
                       new DepartureEntity("ut", "21:31", "21:36"),
                       new DepartureEntity("amf", "21:50", "21:53"),
                       new DepartureEntity("apd", "22:17", "22:18"),
                       new DepartureEntity("dv", "22:28", "22:30"),
                       new DepartureEntity("aml", "22:55", "22:56"),
                       new DepartureEntity("hgl", "23:07", "23:08"),
                       new DepartureEntity("es", "23:17", "23:17"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "761", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "20:50", "20:50"),
                       new DepartureEntity("rta", "20:58", "20:58"),
                       new DepartureEntity("gd", "21:08", "21:13"),
                       new DepartureEntity("ut", "21:31", "21:36"),
                       new DepartureEntity("amf", "21:50", "21:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "762", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "20:50", "20:50"),
                       new DepartureEntity("rta", "20:58", "20:58"),
                       new DepartureEntity("gd", "21:08", "21:13"),
                       new DepartureEntity("ut", "21:31", "21:36"),
                       new DepartureEntity("amf", "21:50", "21:53"),
                       new DepartureEntity("apd", "22:17", "22:18"),
                       new DepartureEntity("dv", "22:28", "22:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "763", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "20:50", "20:50"),
                       new DepartureEntity("rta", "20:58", "20:58"),
                       new DepartureEntity("gd", "21:08", "21:13"),
                       new DepartureEntity("ut", "21:31", "21:36"),
                       new DepartureEntity("amf", "21:50", "21:53"),
                       new DepartureEntity("apd", "22:17", "22:18"),
                       new DepartureEntity("dv", "22:28", "22:30"),
                       new DepartureEntity("aml", "22:55", "22:56"),
                       new DepartureEntity("hgl", "23:07", "23:08"),
                       new DepartureEntity("es", "23:15", "23:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "764", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "21:36", "21:36"),
                       new DepartureEntity("amf", "21:50", "21:53"),
                       new DepartureEntity("apd", "22:17", "22:18"),
                       new DepartureEntity("dv", "22:28", "22:30"),
                       new DepartureEntity("aml", "22:55", "22:56"),
                       new DepartureEntity("hgl", "23:07", "23:08"),
                       new DepartureEntity("es", "23:15", "23:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "765", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "20:50", "20:50"),
                       new DepartureEntity("gd", "21:07", "21:13"),
                       new DepartureEntity("ut", "21:31", "21:36"),
                       new DepartureEntity("amf", "21:50", "21:53"),
                       new DepartureEntity("apd", "22:17", "22:18"),
                       new DepartureEntity("dv", "22:28", "22:30"),
                       new DepartureEntity("aml", "22:55", "22:56"),
                       new DepartureEntity("hgl", "23:07", "23:08"),
                       new DepartureEntity("es", "23:15", "23:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "766", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "20:54", "20:54"),
                       new DepartureEntity("gd", "21:11", "21:12"),
                       new DepartureEntity("ut", "21:31", "21:36"),
                       new DepartureEntity("amf", "21:50", "21:53"),
                       new DepartureEntity("apd", "22:17", "22:18"),
                       new DepartureEntity("dv", "22:28", "22:30"),
                       new DepartureEntity("aml", "22:55", "22:56"),
                       new DepartureEntity("hgl", "23:07", "23:08"),
                       new DepartureEntity("es", "23:15", "23:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "767", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "20:53", "20:53"),
                       new DepartureEntity("gd", "21:10", "21:13"),
                       new DepartureEntity("ut", "21:31", "21:36"),
                       new DepartureEntity("amf", "21:50", "21:53"),
                       new DepartureEntity("apd", "22:17", "22:18"),
                       new DepartureEntity("dv", "22:28", "22:30"),
                       new DepartureEntity("aml", "22:55", "22:56"),
                       new DepartureEntity("hgl", "23:07", "23:08"),
                       new DepartureEntity("es", "23:17", "23:17"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "768", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "20:54", "20:54"),
                       new DepartureEntity("gd", "21:11", "21:12"),
                       new DepartureEntity("ut", "21:31", "21:36"),
                       new DepartureEntity("amf", "21:50", "21:53"),
                       new DepartureEntity("apd", "22:17", "22:18"),
                       new DepartureEntity("dv", "22:28", "22:30"),
                       new DepartureEntity("aml", "22:55", "22:56"),
                       new DepartureEntity("hgl", "23:07", "23:08"),
                       new DepartureEntity("es", "23:15", "23:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "769", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "20:54", "20:54"),
                       new DepartureEntity("gd", "21:11", "21:12"),
                       new DepartureEntity("ut", "21:31", "21:36"),
                       new DepartureEntity("amf", "21:50", "21:53"),
                       new DepartureEntity("apd", "22:17", "22:18"),
                       new DepartureEntity("dv", "22:28", "22:30"),
                       new DepartureEntity("aml", "22:55", "22:56"),
                       new DepartureEntity("hgl", "23:07", "23:08"),
                       new DepartureEntity("es", "23:15", "23:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "770", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "20:53", "20:53"),
                       new DepartureEntity("gd", "21:10", "21:13"),
                       new DepartureEntity("ut", "21:31", "21:36"),
                       new DepartureEntity("amf", "21:50", "21:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "771", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "20:53", "20:53"),
                       new DepartureEntity("gd", "21:10", "21:13"),
                       new DepartureEntity("ut", "21:31", "21:36"),
                       new DepartureEntity("amf", "21:50", "21:53"),
                       new DepartureEntity("apd", "22:17", "22:18"),
                       new DepartureEntity("dv", "22:28", "22:30"),
                       new DepartureEntity("aml", "22:55", "22:56"),
                       new DepartureEntity("hgl", "23:07", "23:08"),
                       new DepartureEntity("es", "23:15", "23:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "772", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "20:54", "20:54"),
                       new DepartureEntity("gd", "21:11", "21:12"),
                       new DepartureEntity("ut", "21:31", "21:36"),
                       new DepartureEntity("amf", "21:50", "21:53"),
                       new DepartureEntity("apd", "22:17", "22:18"),
                       new DepartureEntity("dv", "22:28", "22:30"),
                       new DepartureEntity("aml", "22:55", "22:56"),
                       new DepartureEntity("hgl", "23:07", "23:08"),
                       new DepartureEntity("es", "23:15", "23:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "773", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("gvc", "20:53", "20:53"),
                       new DepartureEntity("gd", "21:10", "21:13"),
                       new DepartureEntity("ut", "21:31", "21:36"),
                       new DepartureEntity("amf", "21:50", "21:53"),
                       new DepartureEntity("apd", "22:17", "22:18"),
                       new DepartureEntity("dv", "22:28", "22:30"),
                       new DepartureEntity("aml", "22:55", "22:56"),
                       new DepartureEntity("hgl", "23:07", "23:08"),
                       new DepartureEntity("es", "23:15", "23:15"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "774", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "03:32", "03:32"),
                       new DepartureEntity("gd", "03:50", "03:57"),
                       new DepartureEntity("gv", "04:16", "04:23"),
                       new DepartureEntity("ledn", "04:36", "04:38"),
                       new DepartureEntity("shl", "04:54", "05:00"),
                       new DepartureEntity("asd", "05:14", "05:17"),
                       new DepartureEntity("ut", "05:57", "05:57"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "775", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "03:32", "03:32"),
                       new DepartureEntity("gd", "03:50", "03:57"),
                       new DepartureEntity("gv", "04:16", "04:23"),
                       new DepartureEntity("ledn", "04:36", "04:38"),
                       new DepartureEntity("shl", "04:54", "05:00"),
                       new DepartureEntity("asd", "05:14", "05:17"),
                       new DepartureEntity("ut", "05:57", "05:57"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "776", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "03:32", "03:32"),
                       new DepartureEntity("gd", "03:50", "03:57"),
                       new DepartureEntity("gv", "04:16", "04:23"),
                       new DepartureEntity("ledn", "04:36", "04:38"),
                       new DepartureEntity("shl", "04:54", "05:00"),
                       new DepartureEntity("asd", "05:14", "05:17"),
                       new DepartureEntity("ut", "05:57", "05:57"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "777", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "03:32", "03:32"),
                       new DepartureEntity("gd", "03:50", "03:57"),
                       new DepartureEntity("gv", "04:22", "04:23"),
                       new DepartureEntity("ledn", "04:36", "04:38"),
                       new DepartureEntity("shl", "04:54", "05:00"),
                       new DepartureEntity("asd", "05:14", "05:17"),
                       new DepartureEntity("ut", "05:57", "05:57"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "778", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "02:30", "02:30"),
                       new DepartureEntity("tb", "03:00", "03:02"),
                       new DepartureEntity("bd", "03:18", "03:19"),
                       new DepartureEntity("ddr", "03:40", "03:41"),
                       new DepartureEntity("rtd", "03:55", "04:02"),
                       new DepartureEntity("dt", "04:14", "04:14"),
                       new DepartureEntity("gv", "04:22", "04:23"),
                       new DepartureEntity("ledn", "04:36", "04:38"),
                       new DepartureEntity("shl", "04:56", "05:00"),
                       new DepartureEntity("asd", "05:14", "05:15"),
                       new DepartureEntity("ut", "05:51", "05:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "779", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "02:30", "02:30"),
                       new DepartureEntity("tb", "03:00", "03:02"),
                       new DepartureEntity("bd", "03:18", "03:19"),
                       new DepartureEntity("ddr", "03:40", "03:41"),
                       new DepartureEntity("rtd", "03:55", "04:02"),
                       new DepartureEntity("dt", "04:14", "04:14"),
                       new DepartureEntity("gv", "04:22", "04:23"),
                       new DepartureEntity("ledn", "04:36", "04:38"),
                       new DepartureEntity("shl", "04:56", "05:00"),
                       new DepartureEntity("asd", "05:14", "05:17"),
                       new DepartureEntity("ut", "05:51", "05:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "780", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "02:30", "02:30"),
                       new DepartureEntity("tb", "03:00", "03:02"),
                       new DepartureEntity("bd", "03:18", "03:19"),
                       new DepartureEntity("ddr", "03:40", "03:41"),
                       new DepartureEntity("rtd", "03:55", "04:02"),
                       new DepartureEntity("dt", "04:14", "04:14"),
                       new DepartureEntity("gv", "04:22", "04:23"),
                       new DepartureEntity("ledn", "04:36", "04:38"),
                       new DepartureEntity("shl", "04:56", "05:00"),
                       new DepartureEntity("asd", "05:14", "05:17"),
                       new DepartureEntity("ut", "05:51", "05:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "781", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "02:30", "02:30"),
                       new DepartureEntity("tb", "03:00", "03:02"),
                       new DepartureEntity("bd", "03:18", "03:19"),
                       new DepartureEntity("ddr", "03:40", "03:41"),
                       new DepartureEntity("rtd", "03:55", "04:02"),
                       new DepartureEntity("dt", "04:14", "04:14"),
                       new DepartureEntity("gv", "04:22", "04:23"),
                       new DepartureEntity("ledn", "04:36", "04:38"),
                       new DepartureEntity("shl", "04:56", "05:00"),
                       new DepartureEntity("asd", "05:14", "05:15"),
                       new DepartureEntity("ut", "05:51", "05:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "782", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "04:02", "04:02"),
                       new DepartureEntity("dt", "04:14", "04:14"),
                       new DepartureEntity("gv", "04:22", "04:23"),
                       new DepartureEntity("ledn", "04:38", "04:39"),
                       new DepartureEntity("shl", "04:56", "05:00"),
                       new DepartureEntity("asd", "05:14", "05:17"),
                       new DepartureEntity("ut", "05:51", "05:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "783", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "04:02", "04:02"),
                       new DepartureEntity("dt", "04:14", "04:14"),
                       new DepartureEntity("gv", "04:22", "04:23"),
                       new DepartureEntity("ledn", "04:38", "04:40"),
                       new DepartureEntity("asd", "05:14", "05:17"),
                       new DepartureEntity("asb", "05:28", "05:28"),
                       new DepartureEntity("ut", "05:51", "05:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "784", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "04:02", "04:02"),
                       new DepartureEntity("dt", "04:14", "04:14"),
                       new DepartureEntity("gv", "04:22", "04:26"),
                       new DepartureEntity("ledn", "04:40", "04:41"),
                       new DepartureEntity("shl", "04:58", "05:01"),
                       new DepartureEntity("asd", "05:14", "05:17"),
                       new DepartureEntity("ut", "05:51", "05:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "785", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dt", "04:14", "04:14"),
                       new DepartureEntity("gv", "04:22", "04:23"),
                       new DepartureEntity("ledn", "04:36", "04:38"),
                       new DepartureEntity("shl", "04:56", "05:00"),
                       new DepartureEntity("asd", "05:14", "05:15"),
                       new DepartureEntity("ut", "05:51", "05:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "786", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "04:02", "04:02"),
                       new DepartureEntity("dt", "04:14", "04:14"),
                       new DepartureEntity("gv", "04:22", "04:23"),
                       new DepartureEntity("ledn", "04:38", "04:39"),
                       new DepartureEntity("shl", "04:56", "05:00"),
                       new DepartureEntity("asd", "05:14", "05:17"),
                       new DepartureEntity("ut", "05:51", "05:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "787", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "04:02", "04:02"),
                       new DepartureEntity("dt", "04:14", "04:14"),
                       new DepartureEntity("gv", "04:22", "04:23"),
                       new DepartureEntity("ledn", "04:36", "04:38"),
                       new DepartureEntity("asd", "05:08", "05:16"),
                       new DepartureEntity("ut", "05:51", "05:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "788", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "04:02", "04:02"),
                       new DepartureEntity("dt", "04:14", "04:14"),
                       new DepartureEntity("gv", "04:22", "04:23"),
                       new DepartureEntity("ledn", "04:38", "04:39"),
                       new DepartureEntity("shl", "04:56", "05:00"),
                       new DepartureEntity("asd", "05:14", "05:17"),
                       new DepartureEntity("ut", "05:50", "05:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "789", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "04:02", "04:02"),
                       new DepartureEntity("dt", "04:14", "04:14"),
                       new DepartureEntity("gv", "04:22", "04:23"),
                       new DepartureEntity("ledn", "04:38", "04:39"),
                       new DepartureEntity("shl", "04:56", "05:00"),
                       new DepartureEntity("asd", "05:14", "05:17"),
                       new DepartureEntity("ut", "05:51", "05:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "790", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "02:35", "02:35"),
                       new DepartureEntity("tb", "03:00", "03:02"),
                       new DepartureEntity("bd", "03:18", "03:19"),
                       new DepartureEntity("ddr", "03:40", "03:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "791", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("bd", "03:19", "03:19"),
                       new DepartureEntity("ddr", "03:40", "03:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "792", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "03:07", "03:07"),
                       new DepartureEntity("asd", "03:42", "03:45"),
                       new DepartureEntity("shl", "03:59", "04:03"),
                       new DepartureEntity("ledn", "04:21", "04:23"),
                       new DepartureEntity("gv", "04:37", "04:44"),
                       new DepartureEntity("gd", "05:02", "05:10"),
                       new DepartureEntity("rtd", "05:28", "05:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "793", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "03:07", "03:07"),
                       new DepartureEntity("asd", "03:42", "03:45"),
                       new DepartureEntity("shl", "03:59", "04:03"),
                       new DepartureEntity("ledn", "04:21", "04:23"),
                       new DepartureEntity("gv", "04:37", "04:44"),
                       new DepartureEntity("gd", "05:02", "05:10"),
                       new DepartureEntity("rtd", "05:28", "05:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "794", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "03:07", "03:07"),
                       new DepartureEntity("asd", "03:42", "03:45"),
                       new DepartureEntity("shl", "03:59", "04:03"),
                       new DepartureEntity("ledn", "04:21", "04:23"),
                       new DepartureEntity("gv", "04:37", "04:44"),
                       new DepartureEntity("gd", "05:02", "05:10"),
                       new DepartureEntity("rtd", "05:28", "05:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "795", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "03:07", "03:07"),
                       new DepartureEntity("asd", "03:42", "03:45"),
                       new DepartureEntity("shl", "03:59", "04:03"),
                       new DepartureEntity("ledn", "04:21", "04:23"),
                       new DepartureEntity("gv", "04:37", "04:44"),
                       new DepartureEntity("gd", "05:02", "05:10"),
                       new DepartureEntity("rtd", "05:28", "05:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "796", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "03:07", "03:07"),
                       new DepartureEntity("asd", "03:42", "03:45"),
                       new DepartureEntity("shl", "03:59", "04:03"),
                       new DepartureEntity("ledn", "04:21", "04:23"),
                       new DepartureEntity("gv", "04:37", "04:44"),
                       new DepartureEntity("gd", "05:02", "05:10"),
                       new DepartureEntity("rtd", "05:28", "05:28"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "797", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "03:07", "03:07"),
                       new DepartureEntity("asd", "03:42", "03:45"),
                       new DepartureEntity("shl", "03:59", "04:03"),
                       new DepartureEntity("ledn", "04:21", "04:23"),
                       new DepartureEntity("gv", "04:37", "04:38"),
                       new DepartureEntity("dt", "04:46", "04:46"),
                       new DepartureEntity("rtd", "04:59", "04:59"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "798", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "03:07", "03:07"),
                       new DepartureEntity("asd", "03:42", "03:45"),
                       new DepartureEntity("shl", "03:59", "04:03"),
                       new DepartureEntity("ledn", "04:21", "04:23"),
                       new DepartureEntity("gv", "04:37", "04:38"),
                       new DepartureEntity("dt", "04:46", "04:46"),
                       new DepartureEntity("rtd", "04:59", "04:59"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "799", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "03:07", "03:07"),
                       new DepartureEntity("asd", "03:42", "03:45"),
                       new DepartureEntity("shl", "03:59", "04:03"),
                       new DepartureEntity("ledn", "04:21", "04:23"),
                       new DepartureEntity("gv", "04:37", "04:38"),
                       new DepartureEntity("dt", "04:46", "04:46"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "800", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "03:07", "03:07"),
                       new DepartureEntity("asd", "03:42", "03:45"),
                       new DepartureEntity("ledn", "04:16", "04:23"),
                       new DepartureEntity("gv", "04:37", "04:38"),
                       new DepartureEntity("dt", "04:46", "04:46"),
                       new DepartureEntity("rtd", "04:59", "04:59"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "801", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "03:10", "03:10"),
                       new DepartureEntity("asd", "03:42", "03:45"),
                       new DepartureEntity("shl", "03:59", "04:03"),
                       new DepartureEntity("ledn", "04:21", "04:23"),
                       new DepartureEntity("gv", "04:37", "04:38"),
                       new DepartureEntity("dt", "04:46", "04:46"),
                       new DepartureEntity("rtd", "04:59", "04:59"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "802", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "03:07", "03:07"),
                       new DepartureEntity("asd", "03:42", "03:45"),
                       new DepartureEntity("shl", "03:59", "04:03"),
                       new DepartureEntity("ledn", "04:21", "04:23"),
                       new DepartureEntity("gv", "04:37", "04:38"),
                       new DepartureEntity("dt", "04:46", "04:46"),
                       new DepartureEntity("rtd", "04:57", "04:57"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "803", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "03:07", "03:07"),
                       new DepartureEntity("asd", "03:42", "03:45"),
                       new DepartureEntity("shl", "03:59", "04:03"),
                       new DepartureEntity("ledn", "04:21", "04:23"),
                       new DepartureEntity("gv", "04:37", "04:38"),
                       new DepartureEntity("dt", "04:46", "04:46"),
                       new DepartureEntity("rtd", "04:59", "04:59"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "804", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "03:07", "03:07"),
                       new DepartureEntity("asb", "03:25", "03:29"),
                       new DepartureEntity("asd", "03:42", "03:45"),
                       new DepartureEntity("ledn", "04:22", "04:23"),
                       new DepartureEntity("gv", "04:35", "04:37"),
                       new DepartureEntity("dt", "04:43", "04:43"),
                       new DepartureEntity("rtd", "04:57", "04:57"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "805", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "03:07", "03:07"),
                       new DepartureEntity("asb", "03:25", "03:29"),
                       new DepartureEntity("asd", "03:42", "03:45"),
                       new DepartureEntity("ledn", "04:21", "04:23"),
                       new DepartureEntity("gv", "04:35", "04:37"),
                       new DepartureEntity("dt", "04:43", "04:43"),
                       new DepartureEntity("rtd", "04:57", "04:57"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "806", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "03:07", "03:07"),
                       new DepartureEntity("asd", "03:42", "03:45"),
                       new DepartureEntity("shl", "03:59", "04:03"),
                       new DepartureEntity("ledn", "04:21", "04:23"),
                       new DepartureEntity("gv", "04:37", "04:38"),
                       new DepartureEntity("dt", "04:46", "04:46"),
                       new DepartureEntity("rtd", "04:57", "04:57"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "807", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "03:07", "03:07"),
                       new DepartureEntity("asd", "03:42", "03:45"),
                       new DepartureEntity("shl", "03:59", "04:03"),
                       new DepartureEntity("ledn", "04:22", "04:23"),
                       new DepartureEntity("gv", "04:37", "04:38"),
                       new DepartureEntity("dt", "04:46", "04:46"),
                       new DepartureEntity("rtd", "04:57", "04:57"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "808", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "03:07", "03:07"),
                       new DepartureEntity("asd", "03:42", "03:45"),
                       new DepartureEntity("shl", "03:59", "04:03"),
                       new DepartureEntity("ledn", "04:21", "04:23"),
                       new DepartureEntity("gv", "04:37", "04:38"),
                       new DepartureEntity("dt", "04:46", "04:46"),
                       new DepartureEntity("rtd", "04:59", "04:59"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "809", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "03:07", "03:07"),
                       new DepartureEntity("asd", "03:42", "03:45"),
                       new DepartureEntity("shl", "03:59", "04:03"),
                       new DepartureEntity("ledn", "04:21", "04:23"),
                       new DepartureEntity("gv", "04:37", "04:38"),
                       new DepartureEntity("dt", "04:46", "04:46"),
                       new DepartureEntity("rtd", "04:59", "04:59"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "810", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "03:07", "03:07"),
                       new DepartureEntity("asd", "03:42", "03:45"),
                       new DepartureEntity("shl", "03:59", "04:03"),
                       new DepartureEntity("ledn", "04:22", "04:23"),
                       new DepartureEntity("gv", "04:37", "04:38"),
                       new DepartureEntity("dt", "04:46", "04:46"),
                       new DepartureEntity("rtd", "04:59", "04:59"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "811", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "03:07", "03:07"),
                       new DepartureEntity("asd", "03:42", "03:45"),
                       new DepartureEntity("shl", "03:59", "04:03"),
                       new DepartureEntity("ledn", "04:21", "04:23"),
                       new DepartureEntity("gv", "04:37", "04:38"),
                       new DepartureEntity("dt", "04:46", "04:46"),
                       new DepartureEntity("rtd", "04:59", "04:59"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "812", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "03:07", "03:07"),
                       new DepartureEntity("asb", "03:25", "03:29"),
                       new DepartureEntity("asd", "03:42", "03:45"),
                       new DepartureEntity("ledn", "04:22", "04:23"),
                       new DepartureEntity("gv", "04:35", "04:37"),
                       new DepartureEntity("dt", "04:43", "04:43"),
                       new DepartureEntity("rtd", "04:57", "04:57"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "813", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "03:07", "03:07"),
                       new DepartureEntity("asd", "03:42", "03:45"),
                       new DepartureEntity("shl", "03:59", "04:03"),
                       new DepartureEntity("ledn", "04:21", "04:23"),
                       new DepartureEntity("gv", "04:37", "04:38"),
                       new DepartureEntity("dt", "04:46", "04:46"),
                       new DepartureEntity("rtd", "04:57", "04:57"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "814", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "03:07", "03:07"),
                       new DepartureEntity("asd", "03:42", "03:45"),
                       new DepartureEntity("shl", "03:59", "04:03"),
                       new DepartureEntity("ledn", "04:21", "04:23"),
                       new DepartureEntity("gv", "04:37", "04:38"),
                       new DepartureEntity("dt", "04:46", "04:46"),
                       new DepartureEntity("rtd", "04:59", "04:59"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "815", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "02:07", "02:07"),
                       new DepartureEntity("asd", "02:42", "02:45"),
                       new DepartureEntity("shl", "02:59", "03:03"),
                       new DepartureEntity("ledn", "03:21", "03:23"),
                       new DepartureEntity("gv", "03:37", "03:38"),
                       new DepartureEntity("dt", "03:46", "03:46"),
                       new DepartureEntity("rtd", "03:59", "04:02"),
                       new DepartureEntity("ddr", "04:15", "04:17"),
                       new DepartureEntity("bd", "04:33", "04:35"),
                       new DepartureEntity("tb", "04:52", "04:55"),
                       new DepartureEntity("ehv", "05:18", "05:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "816", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "02:07", "02:07"),
                       new DepartureEntity("asd", "02:42", "02:45"),
                       new DepartureEntity("shl", "02:59", "03:03"),
                       new DepartureEntity("ledn", "03:21", "03:23"),
                       new DepartureEntity("gv", "03:37", "03:38"),
                       new DepartureEntity("dt", "03:46", "03:46"),
                       new DepartureEntity("rtd", "03:59", "04:02"),
                       new DepartureEntity("ddr", "04:15", "04:17"),
                       new DepartureEntity("bd", "04:33", "04:35"),
                       new DepartureEntity("tb", "04:52", "04:55"),
                       new DepartureEntity("ehv", "05:18", "05:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "817", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "02:07", "02:07"),
                       new DepartureEntity("asd", "02:42", "02:45"),
                       new DepartureEntity("shl", "02:59", "03:03"),
                       new DepartureEntity("ledn", "03:21", "03:23"),
                       new DepartureEntity("gv", "03:37", "03:44"),
                       new DepartureEntity("gd", "04:02", "04:10"),
                       new DepartureEntity("rtd", "04:27", "04:27"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "818", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "02:07", "02:07"),
                       new DepartureEntity("asd", "02:42", "02:45"),
                       new DepartureEntity("shl", "02:59", "03:03"),
                       new DepartureEntity("ledn", "03:21", "03:23"),
                       new DepartureEntity("gv", "03:37", "03:38"),
                       new DepartureEntity("dt", "03:46", "03:46"),
                       new DepartureEntity("rtd", "03:59", "04:02"),
                       new DepartureEntity("ddr", "04:15", "04:17"),
                       new DepartureEntity("bd", "04:33", "04:35"),
                       new DepartureEntity("tb", "04:52", "04:55"),
                       new DepartureEntity("ehv", "05:18", "05:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "819", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "02:07", "02:07"),
                       new DepartureEntity("asd", "02:42", "02:45"),
                       new DepartureEntity("shl", "02:59", "03:03"),
                       new DepartureEntity("ledn", "03:21", "03:23"),
                       new DepartureEntity("gv", "03:37", "03:38"),
                       new DepartureEntity("dt", "03:46", "03:46"),
                       new DepartureEntity("rtd", "03:59", "04:02"),
                       new DepartureEntity("ddr", "04:15", "04:17"),
                       new DepartureEntity("bd", "04:33", "04:35"),
                       new DepartureEntity("tb", "04:52", "04:55"),
                       new DepartureEntity("ehv", "05:18", "05:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "820", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "02:07", "02:07"),
                       new DepartureEntity("asd", "02:42", "02:45"),
                       new DepartureEntity("shl", "02:59", "03:03"),
                       new DepartureEntity("ledn", "03:21", "03:23"),
                       new DepartureEntity("gv", "03:37", "03:44"),
                       new DepartureEntity("gd", "04:02", "04:10"),
                       new DepartureEntity("rtd", "04:27", "04:27"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "821", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "02:07", "02:07"),
                       new DepartureEntity("asd", "02:42", "02:45"),
                       new DepartureEntity("shl", "02:59", "03:03"),
                       new DepartureEntity("ledn", "03:21", "03:23"),
                       new DepartureEntity("gv", "03:37", "03:38"),
                       new DepartureEntity("dt", "03:46", "03:46"),
                       new DepartureEntity("rtd", "03:59", "04:02"),
                       new DepartureEntity("ddr", "04:15", "04:17"),
                       new DepartureEntity("bd", "04:33", "04:35"),
                       new DepartureEntity("tb", "04:52", "04:55"),
                       new DepartureEntity("ehv", "05:18", "05:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "822", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "02:07", "02:07"),
                       new DepartureEntity("asd", "02:42", "02:45"),
                       new DepartureEntity("shl", "02:59", "03:03"),
                       new DepartureEntity("ledn", "03:21", "03:23"),
                       new DepartureEntity("gv", "03:37", "03:44"),
                       new DepartureEntity("gd", "04:02", "04:10"),
                       new DepartureEntity("rtd", "04:27", "04:27"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "823", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "02:07", "02:07"),
                       new DepartureEntity("asd", "02:42", "02:45"),
                       new DepartureEntity("shl", "02:59", "03:03"),
                       new DepartureEntity("ledn", "03:21", "03:23"),
                       new DepartureEntity("gv", "03:37", "03:44"),
                       new DepartureEntity("gd", "04:02", "04:10"),
                       new DepartureEntity("rtd", "04:27", "04:27"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "824", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "02:07", "02:07"),
                       new DepartureEntity("asd", "02:42", "02:45"),
                       new DepartureEntity("shl", "02:59", "03:03"),
                       new DepartureEntity("ledn", "03:21", "03:23"),
                       new DepartureEntity("gv", "03:37", "03:38"),
                       new DepartureEntity("dt", "03:43", "03:43"),
                       new DepartureEntity("rtd", "03:59", "04:02"),
                       new DepartureEntity("ddr", "04:15", "04:17"),
                       new DepartureEntity("bd", "04:33", "04:35"),
                       new DepartureEntity("tb", "04:52", "04:55"),
                       new DepartureEntity("ehv", "05:18", "05:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "825", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "02:07", "02:07"),
                       new DepartureEntity("asd", "02:42", "02:45"),
                       new DepartureEntity("shl", "02:59", "03:03"),
                       new DepartureEntity("ledn", "03:21", "03:23"),
                       new DepartureEntity("gv", "03:37", "03:38"),
                       new DepartureEntity("dt", "03:46", "03:46"),
                       new DepartureEntity("rtd", "03:59", "04:02"),
                       new DepartureEntity("ddr", "04:15", "04:17"),
                       new DepartureEntity("bd", "04:33", "04:35"),
                       new DepartureEntity("tb", "04:52", "04:55"),
                       new DepartureEntity("ehv", "05:18", "05:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "826", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "02:07", "02:07"),
                       new DepartureEntity("asd", "02:42", "02:45"),
                       new DepartureEntity("shl", "02:59", "03:03"),
                       new DepartureEntity("ledn", "03:21", "03:23"),
                       new DepartureEntity("gv", "03:37", "03:44"),
                       new DepartureEntity("gd", "04:02", "04:10"),
                       new DepartureEntity("rtd", "04:27", "04:27"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "827", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "02:07", "02:07"),
                       new DepartureEntity("asd", "02:42", "02:45"),
                       new DepartureEntity("shl", "02:59", "03:03"),
                       new DepartureEntity("ledn", "03:21", "03:23"),
                       new DepartureEntity("gv", "03:37", "03:44"),
                       new DepartureEntity("gd", "04:02", "04:10"),
                       new DepartureEntity("rtd", "04:27", "04:27"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "828", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "02:07", "02:07"),
                       new DepartureEntity("asd", "02:42", "02:45"),
                       new DepartureEntity("shl", "02:59", "03:03"),
                       new DepartureEntity("ledn", "03:21", "03:23"),
                       new DepartureEntity("gv", "03:37", "03:38"),
                       new DepartureEntity("dt", "03:46", "03:46"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "829", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "02:07", "02:07"),
                       new DepartureEntity("asd", "02:42", "02:45"),
                       new DepartureEntity("shl", "02:59", "03:03"),
                       new DepartureEntity("ledn", "03:21", "03:23"),
                       new DepartureEntity("gv", "03:37", "03:38"),
                       new DepartureEntity("dt", "03:46", "03:46"),
                       new DepartureEntity("rtd", "03:57", "03:57"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "830", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "02:07", "02:07"),
                       new DepartureEntity("asd", "02:42", "02:45"),
                       new DepartureEntity("ledn", "03:16", "03:23"),
                       new DepartureEntity("gv", "03:37", "03:38"),
                       new DepartureEntity("dt", "03:46", "03:46"),
                       new DepartureEntity("rtd", "03:59", "03:59"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "831", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "02:07", "02:07"),
                       new DepartureEntity("asd", "02:42", "02:45"),
                       new DepartureEntity("shl", "02:59", "03:03"),
                       new DepartureEntity("ledn", "03:21", "03:23"),
                       new DepartureEntity("gv", "03:37", "03:38"),
                       new DepartureEntity("dt", "03:46", "03:46"),
                       new DepartureEntity("rtd", "03:59", "03:59"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "832", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "02:07", "02:07"),
                       new DepartureEntity("asb", "02:26", "02:29"),
                       new DepartureEntity("asd", "02:42", "02:45"),
                       new DepartureEntity("ledn", "03:21", "03:23"),
                       new DepartureEntity("gv", "03:37", "03:38"),
                       new DepartureEntity("dt", "03:43", "03:43"),
                       new DepartureEntity("rtd", "03:56", "03:56"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "833", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "02:07", "02:07"),
                       new DepartureEntity("asb", "02:26", "02:29"),
                       new DepartureEntity("asd", "02:42", "02:45"),
                       new DepartureEntity("ledn", "03:21", "03:23"),
                       new DepartureEntity("gv", "03:36", "03:37"),
                       new DepartureEntity("dt", "03:43", "03:43"),
                       new DepartureEntity("rtd", "03:56", "03:56"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "834", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "02:07", "02:07"),
                       new DepartureEntity("asd", "02:42", "02:45"),
                       new DepartureEntity("shl", "02:59", "03:03"),
                       new DepartureEntity("ledn", "03:21", "03:23"),
                       new DepartureEntity("gv", "03:37", "03:38"),
                       new DepartureEntity("dt", "03:46", "03:46"),
                       new DepartureEntity("rtd", "03:57", "03:57"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "835", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "02:07", "02:07"),
                       new DepartureEntity("asb", "02:26", "02:29"),
                       new DepartureEntity("asd", "02:42", "02:45"),
                       new DepartureEntity("ledn", "03:21", "03:23"),
                       new DepartureEntity("gv", "03:36", "03:37"),
                       new DepartureEntity("dt", "03:43", "03:43"),
                       new DepartureEntity("rtd", "03:56", "03:56"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "836", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "02:07", "02:07"),
                       new DepartureEntity("asd", "02:42", "02:45"),
                       new DepartureEntity("shl", "02:59", "03:03"),
                       new DepartureEntity("ledn", "03:21", "03:23"),
                       new DepartureEntity("gv", "03:37", "03:38"),
                       new DepartureEntity("dt", "03:46", "03:46"),
                       new DepartureEntity("rtd", "03:59", "03:59"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "837", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "02:07", "02:07"),
                       new DepartureEntity("asd", "02:42", "02:45"),
                       new DepartureEntity("shl", "02:59", "03:03"),
                       new DepartureEntity("ledn", "03:21", "03:23"),
                       new DepartureEntity("gv", "03:37", "03:38"),
                       new DepartureEntity("dt", "03:46", "03:46"),
                       new DepartureEntity("rtd", "03:57", "03:57"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "838", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "02:07", "02:07"),
                       new DepartureEntity("asd", "02:42", "02:45"),
                       new DepartureEntity("shl", "02:59", "03:03"),
                       new DepartureEntity("ledn", "03:21", "03:23"),
                       new DepartureEntity("dt", "03:46", "03:46"),
                       new DepartureEntity("rtd", "03:59", "03:59"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "839", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ddr", "04:17", "04:17"),
                       new DepartureEntity("bd", "04:33", "04:35"),
                       new DepartureEntity("tb", "04:52", "04:55"),
                       new DepartureEntity("ehv", "05:18", "05:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "840", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ddr", "04:17", "04:17"),
                       new DepartureEntity("bd", "04:33", "04:33"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "841", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "04:32", "04:32"),
                       new DepartureEntity("gd", "04:50", "04:57"),
                       new DepartureEntity("gv", "05:17", "05:23"),
                       new DepartureEntity("ledn", "05:36", "05:41"),
                       new DepartureEntity("shl", "06:00", "06:02"),
                       new DepartureEntity("asd", "06:19", "06:19"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "842", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "04:32", "04:32"),
                       new DepartureEntity("gd", "04:50", "04:57"),
                       new DepartureEntity("gv", "05:16", "05:23"),
                       new DepartureEntity("ledn", "05:36", "05:41"),
                       new DepartureEntity("shl", "06:00", "06:02"),
                       new DepartureEntity("asd", "06:19", "06:19"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "843", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "04:32", "04:32"),
                       new DepartureEntity("gd", "04:50", "04:57"),
                       new DepartureEntity("gv", "05:16", "05:23"),
                       new DepartureEntity("ledn", "05:36", "05:41"),
                       new DepartureEntity("shl", "06:00", "06:02"),
                       new DepartureEntity("asd", "06:19", "06:19"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "844", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "04:32", "04:32"),
                       new DepartureEntity("gd", "04:50", "04:57"),
                       new DepartureEntity("gv", "05:16", "05:23"),
                       new DepartureEntity("ledn", "05:36", "05:41"),
                       new DepartureEntity("shl", "06:00", "06:02"),
                       new DepartureEntity("asd", "06:19", "06:19"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "845", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "04:32", "04:32"),
                       new DepartureEntity("gd", "04:50", "04:57"),
                       new DepartureEntity("gv", "05:16", "05:23"),
                       new DepartureEntity("ledn", "05:36", "05:39"),
                       new DepartureEntity("shl", "06:00", "06:02"),
                       new DepartureEntity("asd", "06:19", "06:19"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "846", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "03:30", "03:30"),
                       new DepartureEntity("tb", "04:00", "04:02"),
                       new DepartureEntity("bd", "04:18", "04:19"),
                       new DepartureEntity("ddr", "04:40", "04:41"),
                       new DepartureEntity("rtd", "04:55", "05:02"),
                       new DepartureEntity("dt", "05:14", "05:14"),
                       new DepartureEntity("gv", "05:22", "05:23"),
                       new DepartureEntity("ledn", "05:36", "05:38"),
                       new DepartureEntity("shl", "05:56", "06:02"),
                       new DepartureEntity("asd", "06:19", "06:22"),
                       new DepartureEntity("ut", "06:49", "06:49"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "847", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "03:30", "03:30"),
                       new DepartureEntity("tb", "04:00", "04:02"),
                       new DepartureEntity("bd", "04:18", "04:19"),
                       new DepartureEntity("ddr", "04:40", "04:41"),
                       new DepartureEntity("rtd", "04:55", "05:02"),
                       new DepartureEntity("dt", "05:14", "05:14"),
                       new DepartureEntity("gv", "05:22", "05:23"),
                       new DepartureEntity("ledn", "05:36", "05:38"),
                       new DepartureEntity("shl", "05:56", "06:02"),
                       new DepartureEntity("asd", "06:19", "06:22"),
                       new DepartureEntity("ut", "06:49", "06:49"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "848", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "03:30", "03:30"),
                       new DepartureEntity("tb", "04:00", "04:02"),
                       new DepartureEntity("bd", "04:18", "04:19"),
                       new DepartureEntity("ddr", "04:40", "04:41"),
                       new DepartureEntity("rtd", "04:55", "05:02"),
                       new DepartureEntity("dt", "05:14", "05:14"),
                       new DepartureEntity("gv", "05:22", "05:23"),
                       new DepartureEntity("ledn", "05:36", "05:38"),
                       new DepartureEntity("shl", "05:56", "06:02"),
                       new DepartureEntity("asd", "06:19", "06:22"),
                       new DepartureEntity("ut", "06:49", "06:49"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "849", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "03:30", "03:30"),
                       new DepartureEntity("tb", "04:00", "04:02"),
                       new DepartureEntity("bd", "04:18", "04:19"),
                       new DepartureEntity("ddr", "04:40", "04:41"),
                       new DepartureEntity("rtd", "04:55", "05:02"),
                       new DepartureEntity("dt", "05:14", "05:14"),
                       new DepartureEntity("gv", "05:22", "05:23"),
                       new DepartureEntity("ledn", "05:36", "05:38"),
                       new DepartureEntity("shl", "05:56", "06:02"),
                       new DepartureEntity("asd", "06:19", "06:22"),
                       new DepartureEntity("ut", "06:49", "06:49"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "850", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "03:30", "03:30"),
                       new DepartureEntity("tb", "04:00", "04:02"),
                       new DepartureEntity("bd", "04:18", "04:19"),
                       new DepartureEntity("ddr", "04:40", "04:41"),
                       new DepartureEntity("rtd", "04:55", "05:02"),
                       new DepartureEntity("dt", "05:14", "05:14"),
                       new DepartureEntity("gv", "05:22", "05:23"),
                       new DepartureEntity("ledn", "05:36", "05:38"),
                       new DepartureEntity("shl", "05:56", "06:02"),
                       new DepartureEntity("asd", "06:19", "06:22"),
                       new DepartureEntity("ut", "06:49", "06:49"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "851", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "05:02", "05:02"),
                       new DepartureEntity("dt", "05:14", "05:14"),
                       new DepartureEntity("gv", "05:22", "05:23"),
                       new DepartureEntity("ledn", "05:36", "05:38"),
                       new DepartureEntity("asd", "06:20", "06:22"),
                       new DepartureEntity("ut", "06:49", "06:49"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "852", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "05:02", "05:02"),
                       new DepartureEntity("dt", "05:14", "05:14"),
                       new DepartureEntity("gv", "05:22", "05:23"),
                       new DepartureEntity("ledn", "05:36", "05:41"),
                       new DepartureEntity("shl", "06:00", "06:02"),
                       new DepartureEntity("asd", "06:19", "06:19"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "853", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "05:04", "05:04"),
                       new DepartureEntity("dt", "05:17", "05:17"),
                       new DepartureEntity("gv", "05:25", "05:26"),
                       new DepartureEntity("ledn", "05:37", "05:41"),
                       new DepartureEntity("shl", "06:00", "06:02"),
                       new DepartureEntity("asd", "06:19", "06:19"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "854", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "05:02", "05:02"),
                       new DepartureEntity("dt", "05:14", "05:15"),
                       new DepartureEntity("gv", "05:22", "05:23"),
                       new DepartureEntity("ledn", "05:36", "05:41"),
                       new DepartureEntity("shl", "06:00", "06:02"),
                       new DepartureEntity("asd", "06:19", "06:19"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "855", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dt", "05:14", "05:14"),
                       new DepartureEntity("gv", "05:22", "05:23"),
                       new DepartureEntity("ledn", "05:36", "05:38"),
                       new DepartureEntity("shl", "05:56", "06:02"),
                       new DepartureEntity("asd", "06:19", "06:22"),
                       new DepartureEntity("ut", "06:51", "06:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "856", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "05:04", "05:04"),
                       new DepartureEntity("dt", "05:17", "05:17"),
                       new DepartureEntity("gv", "05:25", "05:26"),
                       new DepartureEntity("ledn", "05:37", "05:39"),
                       new DepartureEntity("shl", "06:00", "06:02"),
                       new DepartureEntity("asd", "06:19", "06:19"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "857", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "05:02", "05:02"),
                       new DepartureEntity("dt", "05:14", "05:14"),
                       new DepartureEntity("gv", "05:22", "05:23"),
                       new DepartureEntity("ledn", "05:36", "05:39"),
                       new DepartureEntity("shl", "06:00", "06:02"),
                       new DepartureEntity("asd", "06:19", "06:19"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "858", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "05:02", "05:02"),
                       new DepartureEntity("dt", "05:14", "05:14"),
                       new DepartureEntity("gv", "05:22", "05:23"),
                       new DepartureEntity("ledn", "05:36", "05:39"),
                       new DepartureEntity("shl", "06:00", "06:02"),
                       new DepartureEntity("asd", "06:19", "06:19"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "859", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "03:35", "03:35"),
                       new DepartureEntity("tb", "04:00", "04:02"),
                       new DepartureEntity("bd", "04:18", "04:19"),
                       new DepartureEntity("ddr", "04:40", "04:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "860", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("bd", "04:19", "04:19"),
                       new DepartureEntity("ddr", "04:40", "04:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "861", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "08:49", "08:49"),
                       new DepartureEntity("ehb", "08:52", "08:52"),
                       new DepartureEntity("bet", "08:58", "08:58"),
                       new DepartureEntity("btl", "09:07", "09:07"),
                       new DepartureEntity("vg", "09:13", "09:13"),
                       new DepartureEntity("ht", "09:18", "09:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "862", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "08:49", "08:49"),
                       new DepartureEntity("ehb", "08:52", "08:52"),
                       new DepartureEntity("bet", "08:58", "08:58"),
                       new DepartureEntity("btl", "09:07", "09:07"),
                       new DepartureEntity("vg", "09:13", "09:13"),
                       new DepartureEntity("ht", "09:18", "09:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "863", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ht", "11:10", "11:10"),
                       new DepartureEntity("vg", "11:15", "11:15"),
                       new DepartureEntity("btl", "11:23", "11:23"),
                       new DepartureEntity("bet", "11:30", "11:30"),
                       new DepartureEntity("ehb", "11:36", "11:36"),
                       new DepartureEntity("ehv", "11:40", "11:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "864", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ht", "11:10", "11:10"),
                       new DepartureEntity("vg", "11:15", "11:15"),
                       new DepartureEntity("btl", "11:23", "11:23"),
                       new DepartureEntity("bet", "11:30", "11:30"),
                       new DepartureEntity("ehb", "11:36", "11:36"),
                       new DepartureEntity("ehv", "11:40", "11:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "865", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "12:51", "12:51"),
                       new DepartureEntity("ehb", "12:54", "12:54"),
                       new DepartureEntity("bet", "13:00", "13:00"),
                       new DepartureEntity("btl", "13:07", "13:07"),
                       new DepartureEntity("vg", "13:13", "13:13"),
                       new DepartureEntity("ht", "13:18", "13:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "866", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "12:49", "12:49"),
                       new DepartureEntity("ehb", "12:52", "12:52"),
                       new DepartureEntity("bet", "12:58", "12:58"),
                       new DepartureEntity("btl", "13:07", "13:07"),
                       new DepartureEntity("vg", "13:13", "13:13"),
                       new DepartureEntity("ht", "13:18", "13:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "867", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ht", "15:10", "15:10"),
                       new DepartureEntity("vg", "15:15", "15:15"),
                       new DepartureEntity("btl", "15:23", "15:23"),
                       new DepartureEntity("bet", "15:30", "15:30"),
                       new DepartureEntity("ehb", "15:36", "15:36"),
                       new DepartureEntity("ehv", "15:40", "15:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "868", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ht", "15:10", "15:10"),
                       new DepartureEntity("vg", "15:15", "15:15"),
                       new DepartureEntity("btl", "15:23", "15:23"),
                       new DepartureEntity("bet", "15:30", "15:30"),
                       new DepartureEntity("ehb", "15:36", "15:36"),
                       new DepartureEntity("ehv", "15:40", "15:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "869", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ht", "19:10", "19:10"),
                       new DepartureEntity("vg", "19:15", "19:15"),
                       new DepartureEntity("btl", "19:23", "19:23"),
                       new DepartureEntity("bet", "19:30", "19:30"),
                       new DepartureEntity("ehb", "19:36", "19:36"),
                       new DepartureEntity("ehv", "19:40", "19:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "870", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ht", "19:10", "19:10"),
                       new DepartureEntity("vg", "19:15", "19:15"),
                       new DepartureEntity("btl", "19:23", "19:23"),
                       new DepartureEntity("bet", "19:30", "19:30"),
                       new DepartureEntity("ehb", "19:36", "19:36"),
                       new DepartureEntity("ehv", "19:40", "19:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "871", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "06:49", "06:49"),
                       new DepartureEntity("ehb", "06:52", "06:52"),
                       new DepartureEntity("bet", "06:58", "06:58"),
                       new DepartureEntity("btl", "07:07", "07:07"),
                       new DepartureEntity("vg", "07:13", "07:13"),
                       new DepartureEntity("ht", "07:18", "07:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "872", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "06:49", "06:49"),
                       new DepartureEntity("ehb", "06:52", "06:52"),
                       new DepartureEntity("bet", "06:58", "06:58"),
                       new DepartureEntity("btl", "07:07", "07:07"),
                       new DepartureEntity("vg", "07:13", "07:13"),
                       new DepartureEntity("ht", "07:18", "07:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "873", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ht", "09:10", "09:10"),
                       new DepartureEntity("vg", "09:15", "09:15"),
                       new DepartureEntity("btl", "09:23", "09:23"),
                       new DepartureEntity("bet", "09:30", "09:30"),
                       new DepartureEntity("ehb", "09:36", "09:36"),
                       new DepartureEntity("ehv", "09:40", "09:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "874", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ht", "09:10", "09:10"),
                       new DepartureEntity("vg", "09:15", "09:15"),
                       new DepartureEntity("btl", "09:23", "09:23"),
                       new DepartureEntity("bet", "09:30", "09:30"),
                       new DepartureEntity("ehb", "09:36", "09:36"),
                       new DepartureEntity("ehv", "09:40", "09:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "875", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "10:49", "10:49"),
                       new DepartureEntity("ehb", "10:53", "10:53"),
                       new DepartureEntity("bet", "10:59", "10:59"),
                       new DepartureEntity("btl", "11:07", "11:07"),
                       new DepartureEntity("vg", "11:13", "11:13"),
                       new DepartureEntity("ht", "11:18", "11:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "876", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "10:49", "10:49"),
                       new DepartureEntity("ehb", "10:53", "10:53"),
                       new DepartureEntity("bet", "10:59", "10:59"),
                       new DepartureEntity("btl", "11:07", "11:07"),
                       new DepartureEntity("vg", "11:13", "11:13"),
                       new DepartureEntity("ht", "11:18", "11:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "877", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ht", "13:11", "13:11"),
                       new DepartureEntity("vg", "13:15", "13:15"),
                       new DepartureEntity("btl", "13:23", "13:23"),
                       new DepartureEntity("bet", "13:30", "13:30"),
                       new DepartureEntity("ehb", "13:36", "13:36"),
                       new DepartureEntity("ehv", "13:40", "13:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "878", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ht", "13:10", "13:10"),
                       new DepartureEntity("vg", "13:15", "13:15"),
                       new DepartureEntity("btl", "13:23", "13:23"),
                       new DepartureEntity("bet", "13:30", "13:30"),
                       new DepartureEntity("ehb", "13:36", "13:36"),
                       new DepartureEntity("ehv", "13:40", "13:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "879", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "14:49", "14:49"),
                       new DepartureEntity("ehb", "14:52", "14:52"),
                       new DepartureEntity("bet", "14:58", "14:58"),
                       new DepartureEntity("btl", "15:07", "15:07"),
                       new DepartureEntity("vg", "15:13", "15:13"),
                       new DepartureEntity("ht", "15:18", "15:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "880", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "14:49", "14:49"),
                       new DepartureEntity("ehb", "14:52", "14:52"),
                       new DepartureEntity("bet", "14:58", "14:58"),
                       new DepartureEntity("btl", "15:07", "15:07"),
                       new DepartureEntity("vg", "15:13", "15:13"),
                       new DepartureEntity("ht", "15:18", "15:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "881", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ht", "17:10", "17:10"),
                       new DepartureEntity("vg", "17:15", "17:15"),
                       new DepartureEntity("btl", "17:23", "17:23"),
                       new DepartureEntity("bet", "17:30", "17:30"),
                       new DepartureEntity("ehb", "17:36", "17:36"),
                       new DepartureEntity("ehv", "17:40", "17:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "882", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "07:49", "07:49"),
                       new DepartureEntity("ehb", "07:52", "07:52"),
                       new DepartureEntity("bet", "07:58", "07:58"),
                       new DepartureEntity("btl", "08:07", "08:07"),
                       new DepartureEntity("vg", "08:13", "08:13"),
                       new DepartureEntity("ht", "08:18", "08:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "883", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "07:49", "07:49"),
                       new DepartureEntity("ehb", "07:52", "07:52"),
                       new DepartureEntity("bet", "07:58", "07:58"),
                       new DepartureEntity("btl", "08:07", "08:07"),
                       new DepartureEntity("vg", "08:13", "08:13"),
                       new DepartureEntity("ht", "08:18", "08:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "884", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ht", "10:10", "10:10"),
                       new DepartureEntity("vg", "10:15", "10:15"),
                       new DepartureEntity("btl", "10:23", "10:23"),
                       new DepartureEntity("bet", "10:30", "10:30"),
                       new DepartureEntity("ehb", "10:36", "10:36"),
                       new DepartureEntity("ehv", "10:40", "10:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "885", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ht", "10:10", "10:10"),
                       new DepartureEntity("vg", "10:15", "10:15"),
                       new DepartureEntity("btl", "10:23", "10:23"),
                       new DepartureEntity("bet", "10:30", "10:30"),
                       new DepartureEntity("ehb", "10:36", "10:36"),
                       new DepartureEntity("ehv", "10:40", "10:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "886", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "11:49", "11:49"),
                       new DepartureEntity("ehb", "11:52", "11:52"),
                       new DepartureEntity("bet", "11:58", "11:58"),
                       new DepartureEntity("btl", "12:07", "12:07"),
                       new DepartureEntity("vg", "12:13", "12:13"),
                       new DepartureEntity("ht", "12:18", "12:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "887", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ht", "14:10", "14:10"),
                       new DepartureEntity("vg", "14:15", "14:15"),
                       new DepartureEntity("btl", "14:23", "14:23"),
                       new DepartureEntity("bet", "14:30", "14:30"),
                       new DepartureEntity("ehb", "14:36", "14:36"),
                       new DepartureEntity("ehv", "14:40", "14:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "888", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ht", "14:10", "14:10"),
                       new DepartureEntity("vg", "14:15", "14:15"),
                       new DepartureEntity("btl", "14:23", "14:23"),
                       new DepartureEntity("bet", "14:30", "14:30"),
                       new DepartureEntity("ehb", "14:36", "14:36"),
                       new DepartureEntity("ehv", "14:40", "14:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "889", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ht", "14:10", "14:10"),
                       new DepartureEntity("vg", "14:15", "14:15"),
                       new DepartureEntity("btl", "14:23", "14:23"),
                       new DepartureEntity("bet", "14:30", "14:30"),
                       new DepartureEntity("ehb", "14:36", "14:36"),
                       new DepartureEntity("ehv", "14:40", "14:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "890", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ht", "18:10", "18:10"),
                       new DepartureEntity("vg", "18:15", "18:15"),
                       new DepartureEntity("btl", "18:23", "18:23"),
                       new DepartureEntity("bet", "18:30", "18:30"),
                       new DepartureEntity("ehb", "18:36", "18:36"),
                       new DepartureEntity("ehv", "18:40", "18:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "891", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ht", "08:10", "08:10"),
                       new DepartureEntity("vg", "08:15", "08:15"),
                       new DepartureEntity("btl", "08:23", "08:23"),
                       new DepartureEntity("bet", "08:30", "08:30"),
                       new DepartureEntity("ehb", "08:36", "08:36"),
                       new DepartureEntity("ehv", "08:40", "08:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "892", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ht", "08:10", "08:10"),
                       new DepartureEntity("vg", "08:15", "08:15"),
                       new DepartureEntity("btl", "08:23", "08:23"),
                       new DepartureEntity("bet", "08:30", "08:30"),
                       new DepartureEntity("ehb", "08:36", "08:36"),
                       new DepartureEntity("ehv", "08:40", "08:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "893", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ht", "08:10", "08:10"),
                       new DepartureEntity("vg", "08:15", "08:15"),
                       new DepartureEntity("btl", "08:23", "08:23"),
                       new DepartureEntity("bet", "08:30", "08:30"),
                       new DepartureEntity("ehb", "08:36", "08:36"),
                       new DepartureEntity("ehv", "08:40", "08:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "894", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "09:49", "09:49"),
                       new DepartureEntity("ehb", "09:52", "09:52"),
                       new DepartureEntity("bet", "09:58", "09:58"),
                       new DepartureEntity("btl", "10:07", "10:07"),
                       new DepartureEntity("vg", "10:13", "10:13"),
                       new DepartureEntity("ht", "10:18", "10:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "895", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ht", "12:10", "12:10"),
                       new DepartureEntity("vg", "12:15", "12:15"),
                       new DepartureEntity("btl", "12:23", "12:23"),
                       new DepartureEntity("bet", "12:30", "12:30"),
                       new DepartureEntity("ehb", "12:36", "12:36"),
                       new DepartureEntity("ehv", "12:40", "12:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "896", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ht", "12:10", "12:10"),
                       new DepartureEntity("vg", "12:15", "12:15"),
                       new DepartureEntity("btl", "12:23", "12:23"),
                       new DepartureEntity("bet", "12:30", "12:30"),
                       new DepartureEntity("ehb", "12:36", "12:36"),
                       new DepartureEntity("ehv", "12:40", "12:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "897", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ht", "12:10", "12:10"),
                       new DepartureEntity("vg", "12:15", "12:15"),
                       new DepartureEntity("btl", "12:23", "12:23"),
                       new DepartureEntity("bet", "12:30", "12:30"),
                       new DepartureEntity("ehb", "12:36", "12:36"),
                       new DepartureEntity("ehv", "12:40", "12:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "898", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "13:49", "13:49"),
                       new DepartureEntity("ehb", "13:52", "13:52"),
                       new DepartureEntity("bet", "13:58", "13:58"),
                       new DepartureEntity("btl", "14:07", "14:07"),
                       new DepartureEntity("vg", "14:13", "14:13"),
                       new DepartureEntity("ht", "14:18", "14:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "899", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ht", "16:10", "16:10"),
                       new DepartureEntity("vg", "16:15", "16:15"),
                       new DepartureEntity("btl", "16:23", "16:23"),
                       new DepartureEntity("bet", "16:30", "16:30"),
                       new DepartureEntity("ehb", "16:36", "16:36"),
                       new DepartureEntity("ehv", "16:40", "16:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "900", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ht", "16:10", "16:10"),
                       new DepartureEntity("vg", "16:15", "16:15"),
                       new DepartureEntity("btl", "16:23", "16:23"),
                       new DepartureEntity("bet", "16:30", "16:30"),
                       new DepartureEntity("ehb", "16:36", "16:36"),
                       new DepartureEntity("ehv", "16:40", "16:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "901", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ht", "16:10", "16:10"),
                       new DepartureEntity("vg", "16:15", "16:15"),
                       new DepartureEntity("btl", "16:23", "16:23"),
                       new DepartureEntity("bet", "16:30", "16:30"),
                       new DepartureEntity("ehb", "16:36", "16:36"),
                       new DepartureEntity("ehv", "16:40", "16:40"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "902", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "01:17", "01:17"),
                       new DepartureEntity("asb", "01:28", "01:28"),
                       new DepartureEntity("ut", "01:51", "01:55"),
                       new DepartureEntity("ht", "02:25", "02:26"),
                       new DepartureEntity("ehv", "02:47", "02:47"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "903", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "01:17", "01:17"),
                       new DepartureEntity("asb", "01:28", "01:28"),
                       new DepartureEntity("ut", "01:48", "01:55"),
                       new DepartureEntity("ht", "02:25", "02:26"),
                       new DepartureEntity("ehv", "02:47", "02:47"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "904", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "01:17", "01:17"),
                       new DepartureEntity("asb", "01:28", "01:28"),
                       new DepartureEntity("ut", "01:51", "01:55"),
                       new DepartureEntity("ht", "02:25", "02:26"),
                       new DepartureEntity("ehv", "02:47", "02:47"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "905", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "01:17", "01:17"),
                       new DepartureEntity("asb", "01:28", "01:28"),
                       new DepartureEntity("ut", "01:51", "01:55"),
                       new DepartureEntity("ht", "02:25", "02:26"),
                       new DepartureEntity("ehv", "02:47", "02:47"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "906", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "01:17", "01:17"),
                       new DepartureEntity("asb", "01:28", "01:28"),
                       new DepartureEntity("ut", "01:51", "01:55"),
                       new DepartureEntity("ht", "02:25", "02:26"),
                       new DepartureEntity("ehv", "02:47", "02:47"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "907", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "01:17", "01:17"),
                       new DepartureEntity("ut", "01:57", "01:57"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "908", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "01:17", "01:17"),
                       new DepartureEntity("asb", "01:28", "01:28"),
                       new DepartureEntity("ut", "01:51", "01:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "909", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "01:18", "01:18"),
                       new DepartureEntity("asb", "01:30", "01:30"),
                       new DepartureEntity("ut", "01:51", "01:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "910", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "01:17", "01:17"),
                       new DepartureEntity("ut", "01:57", "01:57"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "911", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "01:17", "01:17"),
                       new DepartureEntity("asb", "01:28", "01:28"),
                       new DepartureEntity("ut", "01:51", "01:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "912", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "01:17", "01:17"),
                       new DepartureEntity("asb", "01:28", "01:28"),
                       new DepartureEntity("ut", "01:51", "01:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "913", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "01:17", "01:17"),
                       new DepartureEntity("asb", "01:28", "01:28"),
                       new DepartureEntity("ut", "01:51", "01:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "914", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "01:17", "01:17"),
                       new DepartureEntity("asb", "01:28", "01:33"),
                       new DepartureEntity("ut", "01:51", "01:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "915", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "01:17", "01:17"),
                       new DepartureEntity("asb", "01:28", "01:28"),
                       new DepartureEntity("ut", "01:51", "01:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "916", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "01:17", "01:17"),
                       new DepartureEntity("asb", "01:28", "01:28"),
                       new DepartureEntity("ut", "01:51", "01:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "917", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "01:17", "01:17"),
                       new DepartureEntity("asb", "01:28", "01:28"),
                       new DepartureEntity("ut", "01:51", "01:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "918", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ht", "02:26", "02:26"),
                       new DepartureEntity("ehv", "02:47", "02:47"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "919", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("btl", "00:57", "00:57"),
                       new DepartureEntity("bet", "01:04", "01:04"),
                       new DepartureEntity("ehb", "01:09", "01:09"),
                       new DepartureEntity("ehv", "01:13", "01:13"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "920", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "00:45", "00:45"),
                       new DepartureEntity("ass", "00:49", "00:49"),
                       new DepartureEntity("shl", "00:59", "01:03"),
                       new DepartureEntity("ledn", "01:21", "01:23"),
                       new DepartureEntity("gv", "01:39", "01:40"),
                       new DepartureEntity("dt", "01:46", "01:46"),
                       new DepartureEntity("rtd", "01:59", "02:02"),
                       new DepartureEntity("ddr", "02:15", "02:17"),
                       new DepartureEntity("bd", "02:33", "02:35"),
                       new DepartureEntity("tb", "02:52", "02:55"),
                       new DepartureEntity("ehv", "03:18", "03:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "921", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "00:46", "00:46"),
                       new DepartureEntity("ass", "00:53", "00:53"),
                       new DepartureEntity("shl", "01:00", "01:03"),
                       new DepartureEntity("ledn", "01:21", "01:23"),
                       new DepartureEntity("gv", "01:37", "01:38"),
                       new DepartureEntity("dt", "01:46", "01:46"),
                       new DepartureEntity("rtd", "01:59", "02:02"),
                       new DepartureEntity("ddr", "02:15", "02:17"),
                       new DepartureEntity("bd", "02:33", "02:35"),
                       new DepartureEntity("tb", "02:52", "02:55"),
                       new DepartureEntity("ehv", "03:18", "03:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "922", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "00:45", "00:45"),
                       new DepartureEntity("ass", "00:49", "00:49"),
                       new DepartureEntity("shl", "00:59", "01:03"),
                       new DepartureEntity("ledn", "01:20", "01:23"),
                       new DepartureEntity("gv", "01:37", "01:45"),
                       new DepartureEntity("gd", "02:03", "02:10"),
                       new DepartureEntity("rtd", "02:27", "02:27"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "923", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "00:45", "00:45"),
                       new DepartureEntity("ass", "00:49", "00:49"),
                       new DepartureEntity("shl", "00:59", "01:03"),
                       new DepartureEntity("ledn", "01:21", "01:24"),
                       new DepartureEntity("gv", "01:38", "01:39"),
                       new DepartureEntity("dt", "01:46", "01:46"),
                       new DepartureEntity("rtd", "01:59", "02:02"),
                       new DepartureEntity("ddr", "02:16", "02:17"),
                       new DepartureEntity("bd", "02:33", "02:35"),
                       new DepartureEntity("tb", "02:52", "02:55"),
                       new DepartureEntity("ehv", "03:18", "03:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "924", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "00:45", "00:45"),
                       new DepartureEntity("ass", "00:49", "00:49"),
                       new DepartureEntity("shl", "00:59", "01:03"),
                       new DepartureEntity("ledn", "01:20", "01:23"),
                       new DepartureEntity("gv", "01:37", "01:45"),
                       new DepartureEntity("gd", "02:03", "02:10"),
                       new DepartureEntity("rtd", "02:27", "02:27"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "925", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "00:45", "00:45"),
                       new DepartureEntity("ass", "00:49", "00:49"),
                       new DepartureEntity("shl", "00:59", "01:02"),
                       new DepartureEntity("ledn", "01:19", "01:23"),
                       new DepartureEntity("gv", "01:37", "01:45"),
                       new DepartureEntity("gd", "02:03", "02:10"),
                       new DepartureEntity("rtd", "02:26", "02:26"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "926", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "00:45", "00:45"),
                       new DepartureEntity("ass", "00:49", "00:49"),
                       new DepartureEntity("shl", "00:59", "01:03"),
                       new DepartureEntity("ledn", "01:21", "01:23"),
                       new DepartureEntity("gv", "01:37", "01:38"),
                       new DepartureEntity("dt", "01:46", "01:46"),
                       new DepartureEntity("rtd", "01:59", "02:02"),
                       new DepartureEntity("ddr", "02:15", "02:17"),
                       new DepartureEntity("bd", "02:33", "02:35"),
                       new DepartureEntity("tb", "02:52", "02:55"),
                       new DepartureEntity("ehv", "03:18", "03:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "927", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "00:45", "00:45"),
                       new DepartureEntity("ass", "00:49", "00:49"),
                       new DepartureEntity("shl", "00:59", "01:03"),
                       new DepartureEntity("ledn", "01:20", "01:23"),
                       new DepartureEntity("gv", "01:37", "01:44"),
                       new DepartureEntity("gd", "02:03", "02:10"),
                       new DepartureEntity("rtd", "02:27", "02:27"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "928", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "00:45", "00:45"),
                       new DepartureEntity("ass", "00:49", "00:49"),
                       new DepartureEntity("shl", "00:59", "01:02"),
                       new DepartureEntity("ledn", "01:19", "01:23"),
                       new DepartureEntity("gv", "01:37", "01:44"),
                       new DepartureEntity("gd", "02:03", "02:10"),
                       new DepartureEntity("rtd", "02:26", "02:26"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "929", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "00:45", "00:45"),
                       new DepartureEntity("ass", "00:49", "00:49"),
                       new DepartureEntity("shl", "00:59", "01:03"),
                       new DepartureEntity("ledn", "01:21", "01:23"),
                       new DepartureEntity("gv", "01:37", "01:38"),
                       new DepartureEntity("dt", "01:46", "01:46"),
                       new DepartureEntity("rtd", "01:59", "02:02"),
                       new DepartureEntity("ddr", "02:16", "02:17"),
                       new DepartureEntity("bd", "02:33", "02:35"),
                       new DepartureEntity("tb", "02:52", "02:55"),
                       new DepartureEntity("ehv", "03:18", "03:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "930", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "00:45", "00:45"),
                       new DepartureEntity("ass", "00:49", "00:49"),
                       new DepartureEntity("shl", "00:59", "01:03"),
                       new DepartureEntity("ledn", "01:21", "01:23"),
                       new DepartureEntity("gv", "01:37", "01:38"),
                       new DepartureEntity("dt", "01:46", "01:46"),
                       new DepartureEntity("rtd", "01:59", "02:02"),
                       new DepartureEntity("ddr", "02:15", "02:17"),
                       new DepartureEntity("bd", "02:33", "02:35"),
                       new DepartureEntity("tb", "02:52", "02:55"),
                       new DepartureEntity("ehv", "03:18", "03:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "931", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "00:45", "00:45"),
                       new DepartureEntity("ass", "00:49", "00:49"),
                       new DepartureEntity("shl", "00:59", "01:03"),
                       new DepartureEntity("ledn", "01:21", "01:23"),
                       new DepartureEntity("gv", "01:37", "01:38"),
                       new DepartureEntity("dt", "01:46", "01:46"),
                       new DepartureEntity("rtd", "01:59", "01:59"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "932", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "00:45", "00:45"),
                       new DepartureEntity("ass", "00:50", "00:50"),
                       new DepartureEntity("shl", "00:59", "01:03"),
                       new DepartureEntity("ledn", "01:21", "01:23"),
                       new DepartureEntity("gv", "01:37", "01:38"),
                       new DepartureEntity("dt", "01:46", "01:46"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "933", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "00:45", "00:45"),
                       new DepartureEntity("ass", "00:49", "00:49"),
                       new DepartureEntity("shl", "00:59", "01:03"),
                       new DepartureEntity("ledn", "01:21", "01:23"),
                       new DepartureEntity("gv", "01:39", "01:40"),
                       new DepartureEntity("dt", "01:47", "01:47"),
                       new DepartureEntity("rtd", "01:59", "01:59"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "934", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "00:45", "00:45"),
                       new DepartureEntity("ass", "00:49", "00:49"),
                       new DepartureEntity("shl", "00:59", "01:03"),
                       new DepartureEntity("ledn", "01:21", "01:23"),
                       new DepartureEntity("gv", "01:39", "01:40"),
                       new DepartureEntity("dt", "01:47", "01:47"),
                       new DepartureEntity("rtd", "01:59", "01:59"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "935", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "00:45", "00:45"),
                       new DepartureEntity("ass", "00:49", "00:49"),
                       new DepartureEntity("shl", "00:59", "01:03"),
                       new DepartureEntity("ledn", "01:21", "01:23"),
                       new DepartureEntity("gv", "01:39", "01:40"),
                       new DepartureEntity("dt", "01:47", "01:47"),
                       new DepartureEntity("rtd", "01:59", "01:59"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "936", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "00:45", "00:45"),
                       new DepartureEntity("ass", "00:49", "00:49"),
                       new DepartureEntity("shl", "00:59", "01:03"),
                       new DepartureEntity("ledn", "01:19", "01:22"),
                       new DepartureEntity("gv", "01:38", "01:39"),
                       new DepartureEntity("dt", "01:46", "01:46"),
                       new DepartureEntity("rtd", "01:59", "01:59"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "937", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "00:45", "00:45"),
                       new DepartureEntity("ass", "00:49", "00:49"),
                       new DepartureEntity("shl", "00:59", "01:03"),
                       new DepartureEntity("ledn", "01:19", "01:23"),
                       new DepartureEntity("gv", "01:37", "01:38"),
                       new DepartureEntity("dt", "01:46", "01:46"),
                       new DepartureEntity("rtd", "01:59", "01:59"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "938", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ddr", "02:17", "02:17"),
                       new DepartureEntity("bd", "02:33", "02:35"),
                       new DepartureEntity("tb", "02:52", "02:55"),
                       new DepartureEntity("ehv", "03:18", "03:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "939", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ddr", "02:17", "02:17"),
                       new DepartureEntity("bd", "02:33", "02:33"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "940", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "01:45", "01:45"),
                       new DepartureEntity("shl", "01:59", "02:00"),
                       new DepartureEntity("ledn", "02:21", "02:23"),
                       new DepartureEntity("gv", "02:37", "02:44"),
                       new DepartureEntity("gd", "03:04", "03:11"),
                       new DepartureEntity("rtd", "03:26", "03:26"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "941", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "01:45", "01:45"),
                       new DepartureEntity("shl", "01:59", "02:03"),
                       new DepartureEntity("ledn", "02:21", "02:23"),
                       new DepartureEntity("gv", "02:37", "02:38"),
                       new DepartureEntity("dt", "02:46", "02:46"),
                       new DepartureEntity("rtd", "02:59", "03:02"),
                       new DepartureEntity("ddr", "03:15", "03:17"),
                       new DepartureEntity("bd", "03:33", "03:35"),
                       new DepartureEntity("tb", "03:52", "03:55"),
                       new DepartureEntity("ehv", "04:18", "04:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "942", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "01:45", "01:45"),
                       new DepartureEntity("shl", "01:59", "02:03"),
                       new DepartureEntity("ledn", "02:21", "02:23"),
                       new DepartureEntity("gv", "02:37", "02:38"),
                       new DepartureEntity("dt", "02:46", "02:46"),
                       new DepartureEntity("rtd", "02:59", "03:02"),
                       new DepartureEntity("ddr", "03:15", "03:17"),
                       new DepartureEntity("bd", "03:33", "03:35"),
                       new DepartureEntity("tb", "03:52", "03:55"),
                       new DepartureEntity("ehv", "04:18", "04:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "943", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "01:45", "01:45"),
                       new DepartureEntity("shl", "01:59", "02:03"),
                       new DepartureEntity("ledn", "02:21", "02:23"),
                       new DepartureEntity("gv", "02:37", "02:44"),
                       new DepartureEntity("gd", "03:02", "03:10"),
                       new DepartureEntity("rtd", "03:26", "03:26"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "944", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "01:45", "01:45"),
                       new DepartureEntity("shl", "01:59", "02:03"),
                       new DepartureEntity("ledn", "02:21", "02:23"),
                       new DepartureEntity("gv", "02:37", "02:38"),
                       new DepartureEntity("dt", "02:46", "02:46"),
                       new DepartureEntity("rtd", "02:59", "03:02"),
                       new DepartureEntity("ddr", "03:15", "03:17"),
                       new DepartureEntity("bd", "03:33", "03:35"),
                       new DepartureEntity("tb", "03:52", "03:55"),
                       new DepartureEntity("ehv", "04:18", "04:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "945", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "01:45", "01:45"),
                       new DepartureEntity("shl", "01:59", "02:03"),
                       new DepartureEntity("ledn", "02:21", "02:23"),
                       new DepartureEntity("gv", "02:37", "02:44"),
                       new DepartureEntity("gd", "03:02", "03:10"),
                       new DepartureEntity("rtd", "03:26", "03:26"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "946", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "01:45", "01:45"),
                       new DepartureEntity("shl", "01:59", "02:03"),
                       new DepartureEntity("ledn", "02:21", "02:23"),
                       new DepartureEntity("gv", "02:37", "02:44"),
                       new DepartureEntity("gd", "03:02", "03:10"),
                       new DepartureEntity("rtd", "03:26", "03:26"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "947", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "01:45", "01:45"),
                       new DepartureEntity("shl", "01:59", "02:03"),
                       new DepartureEntity("ledn", "02:21", "02:23"),
                       new DepartureEntity("gv", "02:37", "02:44"),
                       new DepartureEntity("gd", "03:02", "03:10"),
                       new DepartureEntity("rtd", "03:26", "03:26"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "948", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "01:45", "01:45"),
                       new DepartureEntity("shl", "01:59", "02:03"),
                       new DepartureEntity("ledn", "02:21", "02:23"),
                       new DepartureEntity("gv", "02:37", "02:44"),
                       new DepartureEntity("gd", "03:02", "03:10"),
                       new DepartureEntity("rtd", "03:26", "03:26"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "949", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "01:45", "01:45"),
                       new DepartureEntity("shl", "01:59", "02:03"),
                       new DepartureEntity("ledn", "02:21", "02:23"),
                       new DepartureEntity("gv", "02:37", "02:38"),
                       new DepartureEntity("dt", "02:46", "02:46"),
                       new DepartureEntity("rtd", "02:59", "03:02"),
                       new DepartureEntity("ddr", "03:15", "03:17"),
                       new DepartureEntity("bd", "03:33", "03:35"),
                       new DepartureEntity("tb", "03:52", "03:55"),
                       new DepartureEntity("ehv", "04:18", "04:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "950", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "01:45", "01:45"),
                       new DepartureEntity("shl", "01:59", "02:03"),
                       new DepartureEntity("ledn", "02:21", "02:23"),
                       new DepartureEntity("gv", "02:37", "02:38"),
                       new DepartureEntity("dt", "02:46", "02:46"),
                       new DepartureEntity("rtd", "02:59", "03:02"),
                       new DepartureEntity("ddr", "03:15", "03:17"),
                       new DepartureEntity("bd", "03:33", "03:35"),
                       new DepartureEntity("tb", "03:52", "03:55"),
                       new DepartureEntity("ehv", "04:18", "04:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "951", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "00:59", "00:59"),
                       new DepartureEntity("asb", "01:15", "01:15"),
                       new DepartureEntity("asd", "01:26", "01:45"),
                       new DepartureEntity("shl", "01:59", "02:03"),
                       new DepartureEntity("ledn", "02:21", "02:23"),
                       new DepartureEntity("gv", "02:37", "02:44"),
                       new DepartureEntity("gd", "03:02", "03:02"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "952", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "00:58", "00:58"),
                       new DepartureEntity("asb", "01:14", "01:32"),
                       new DepartureEntity("asd", "01:43", "01:45"),
                       new DepartureEntity("ledn", "02:21", "02:23"),
                       new DepartureEntity("gv", "02:35", "02:37"),
                       new DepartureEntity("dt", "02:43", "02:43"),
                       new DepartureEntity("rtd", "02:56", "02:56"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "953", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "00:58", "00:58"),
                       new DepartureEntity("asb", "01:15", "01:15"),
                       new DepartureEntity("asd", "01:26", "01:45"),
                       new DepartureEntity("shl", "01:59", "02:03"),
                       new DepartureEntity("ledn", "02:21", "02:23"),
                       new DepartureEntity("gv", "02:37", "02:38"),
                       new DepartureEntity("dt", "02:46", "02:46"),
                       new DepartureEntity("rtd", "02:57", "02:57"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "954", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "00:58", "00:58"),
                       new DepartureEntity("asb", "01:15", "01:15"),
                       new DepartureEntity("asd", "01:26", "01:45"),
                       new DepartureEntity("shl", "01:59", "02:03"),
                       new DepartureEntity("ledn", "02:21", "02:23"),
                       new DepartureEntity("gv", "02:37", "02:38"),
                       new DepartureEntity("dt", "02:46", "02:46"),
                       new DepartureEntity("rtd", "02:59", "02:59"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "955", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "01:02", "01:02"),
                       new DepartureEntity("asd", "01:41", "01:45"),
                       new DepartureEntity("shl", "01:59", "02:00"),
                       new DepartureEntity("ledn", "02:21", "02:23"),
                       new DepartureEntity("gv", "02:37", "02:44"),
                       new DepartureEntity("gd", "03:04", "03:04"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "956", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "00:58", "00:58"),
                       new DepartureEntity("asb", "01:15", "01:15"),
                       new DepartureEntity("asd", "01:26", "01:45"),
                       new DepartureEntity("shl", "01:59", "02:03"),
                       new DepartureEntity("ledn", "02:21", "02:23"),
                       new DepartureEntity("gv", "02:37", "02:38"),
                       new DepartureEntity("dt", "02:46", "02:46"),
                       new DepartureEntity("rtd", "02:59", "02:59"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "957", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "00:58", "00:58"),
                       new DepartureEntity("asb", "01:14", "01:14"),
                       new DepartureEntity("asd", "01:26", "01:45"),
                       new DepartureEntity("shl", "01:59", "02:03"),
                       new DepartureEntity("ledn", "02:21", "02:23"),
                       new DepartureEntity("gv", "02:37", "02:38"),
                       new DepartureEntity("dt", "02:46", "02:46"),
                       new DepartureEntity("rtd", "02:59", "02:59"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "958", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "00:58", "00:58"),
                       new DepartureEntity("asb", "01:14", "01:32"),
                       new DepartureEntity("asd", "01:43", "01:45"),
                       new DepartureEntity("ledn", "02:21", "02:23"),
                       new DepartureEntity("gv", "02:35", "02:37"),
                       new DepartureEntity("dt", "02:43", "02:43"),
                       new DepartureEntity("rtd", "02:56", "02:56"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "959", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "00:59", "00:59"),
                       new DepartureEntity("asb", "01:14", "01:14"),
                       new DepartureEntity("asd", "01:26", "01:45"),
                       new DepartureEntity("shl", "01:59", "02:03"),
                       new DepartureEntity("ledn", "02:21", "02:23"),
                       new DepartureEntity("gv", "02:37", "02:44"),
                       new DepartureEntity("gd", "03:02", "03:02"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "960", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "00:59", "00:59"),
                       new DepartureEntity("asb", "01:14", "01:14"),
                       new DepartureEntity("asd", "01:26", "01:45"),
                       new DepartureEntity("shl", "01:59", "02:03"),
                       new DepartureEntity("ledn", "02:21", "02:23"),
                       new DepartureEntity("gv", "02:37", "02:44"),
                       new DepartureEntity("gd", "03:02", "03:02"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "961", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "00:59", "00:59"),
                       new DepartureEntity("asb", "01:14", "01:14"),
                       new DepartureEntity("asd", "01:26", "01:45"),
                       new DepartureEntity("shl", "01:59", "02:03"),
                       new DepartureEntity("ledn", "02:21", "02:23"),
                       new DepartureEntity("gv", "02:37", "02:44"),
                       new DepartureEntity("gd", "03:02", "03:02"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "962", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "00:58", "00:58"),
                       new DepartureEntity("asb", "01:14", "01:14"),
                       new DepartureEntity("asd", "01:26", "01:45"),
                       new DepartureEntity("ledn", "02:16", "02:23"),
                       new DepartureEntity("gv", "02:37", "02:38"),
                       new DepartureEntity("dt", "02:46", "02:46"),
                       new DepartureEntity("rtd", "02:59", "02:59"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "963", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "00:58", "00:58"),
                       new DepartureEntity("asb", "01:14", "01:14"),
                       new DepartureEntity("asd", "01:26", "01:45"),
                       new DepartureEntity("shl", "01:59", "02:03"),
                       new DepartureEntity("ledn", "02:21", "02:23"),
                       new DepartureEntity("gv", "02:37", "02:38"),
                       new DepartureEntity("dt", "02:46", "02:46"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "964", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "00:58", "00:58"),
                       new DepartureEntity("asb", "01:14", "01:32"),
                       new DepartureEntity("asd", "01:43", "01:45"),
                       new DepartureEntity("ledn", "02:21", "02:23"),
                       new DepartureEntity("gv", "02:35", "02:37"),
                       new DepartureEntity("dt", "02:43", "02:43"),
                       new DepartureEntity("rtd", "02:56", "02:56"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "965", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "00:58", "00:58"),
                       new DepartureEntity("asb", "01:14", "01:14"),
                       new DepartureEntity("asd", "01:29", "01:45"),
                       new DepartureEntity("shl", "01:59", "02:03"),
                       new DepartureEntity("ledn", "02:21", "02:23"),
                       new DepartureEntity("gv", "02:37", "02:38"),
                       new DepartureEntity("dt", "02:46", "02:46"),
                       new DepartureEntity("rtd", "02:59", "02:59"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "966", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "00:58", "00:58"),
                       new DepartureEntity("asb", "01:15", "01:15"),
                       new DepartureEntity("asd", "01:26", "01:45"),
                       new DepartureEntity("shl", "01:59", "02:03"),
                       new DepartureEntity("ledn", "02:21", "02:23"),
                       new DepartureEntity("gv", "02:37", "02:38"),
                       new DepartureEntity("dt", "02:46", "02:46"),
                       new DepartureEntity("rtd", "02:59", "02:59"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "967", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "00:58", "00:58"),
                       new DepartureEntity("asb", "01:14", "01:14"),
                       new DepartureEntity("asd", "01:26", "01:45"),
                       new DepartureEntity("shl", "01:59", "02:03"),
                       new DepartureEntity("ledn", "02:21", "02:23"),
                       new DepartureEntity("gv", "02:37", "02:38"),
                       new DepartureEntity("dt", "02:46", "02:46"),
                       new DepartureEntity("rtd", "02:59", "02:59"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "968", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "00:58", "00:58"),
                       new DepartureEntity("asb", "01:15", "01:15"),
                       new DepartureEntity("asd", "01:26", "01:45"),
                       new DepartureEntity("shl", "01:59", "02:03"),
                       new DepartureEntity("ledn", "02:21", "02:23"),
                       new DepartureEntity("gv", "02:37", "02:38"),
                       new DepartureEntity("dt", "02:46", "02:46"),
                       new DepartureEntity("rtd", "02:57", "02:57"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "969", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "00:58", "00:58"),
                       new DepartureEntity("asb", "01:15", "01:15"),
                       new DepartureEntity("asd", "01:26", "01:45"),
                       new DepartureEntity("shl", "01:59", "02:03"),
                       new DepartureEntity("ledn", "02:21", "02:23"),
                       new DepartureEntity("gv", "02:37", "02:38"),
                       new DepartureEntity("dt", "02:46", "02:46"),
                       new DepartureEntity("rtd", "02:57", "02:57"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "970", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "00:58", "00:58"),
                       new DepartureEntity("asb", "01:15", "01:15"),
                       new DepartureEntity("asd", "01:26", "01:45"),
                       new DepartureEntity("shl", "01:59", "02:03"),
                       new DepartureEntity("ledn", "02:21", "02:23"),
                       new DepartureEntity("gv", "02:37", "02:38"),
                       new DepartureEntity("dt", "02:44", "02:44"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "971", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "00:59", "00:59"),
                       new DepartureEntity("asb", "01:14", "01:14"),
                       new DepartureEntity("asd", "01:26", "01:45"),
                       new DepartureEntity("shl", "01:59", "02:03"),
                       new DepartureEntity("ledn", "02:21", "02:23"),
                       new DepartureEntity("gv", "02:37", "02:44"),
                       new DepartureEntity("gd", "03:02", "03:02"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "972", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ut", "00:58", "00:58"),
                       new DepartureEntity("asb", "01:14", "01:14"),
                       new DepartureEntity("asd", "01:26", "01:45"),
                       new DepartureEntity("shl", "01:59", "02:03"),
                       new DepartureEntity("ledn", "02:21", "02:23"),
                       new DepartureEntity("gv", "02:37", "02:38"),
                       new DepartureEntity("dt", "02:46", "02:46"),
                       new DepartureEntity("rtd", "02:59", "02:59"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "973", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ddr", "03:17", "03:17"),
                       new DepartureEntity("bd", "03:33", "03:35"),
                       new DepartureEntity("tb", "03:52", "03:55"),
                       new DepartureEntity("ehv", "04:18", "04:18"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "974", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ddr", "03:17", "03:17"),
                       new DepartureEntity("bd", "03:33", "03:33"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "975", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "02:17", "02:17"),
                       new DepartureEntity("ut", "02:51", "02:55"),
                       new DepartureEntity("ht", "03:25", "03:26"),
                       new DepartureEntity("ehv", "03:47", "03:47"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "976", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "02:17", "02:17"),
                       new DepartureEntity("ut", "02:51", "02:55"),
                       new DepartureEntity("ht", "03:25", "03:26"),
                       new DepartureEntity("ehv", "03:47", "03:47"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "977", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "02:17", "02:17"),
                       new DepartureEntity("ut", "02:51", "02:55"),
                       new DepartureEntity("ht", "03:25", "03:26"),
                       new DepartureEntity("ehv", "03:47", "03:47"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "978", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("asd", "02:15", "02:15"),
                       new DepartureEntity("ut", "02:51", "02:55"),
                       new DepartureEntity("ht", "03:25", "03:26"),
                       new DepartureEntity("ehv", "03:47", "03:47"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "979", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("dt", "01:14", "01:14"),
                       new DepartureEntity("gv", "01:22", "01:23"),
                       new DepartureEntity("ledn", "01:36", "01:38"),
                       new DepartureEntity("shl", "01:56", "02:00"),
                       new DepartureEntity("asd", "02:14", "02:15"),
                       new DepartureEntity("ut", "02:50", "02:50"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "980", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "01:02", "01:02"),
                       new DepartureEntity("dt", "01:14", "01:14"),
                       new DepartureEntity("gv", "01:22", "01:23"),
                       new DepartureEntity("ledn", "01:36", "01:38"),
                       new DepartureEntity("shl", "01:56", "02:00"),
                       new DepartureEntity("asd", "02:14", "02:17"),
                       new DepartureEntity("ut", "02:51", "02:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "981", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "01:02", "01:02"),
                       new DepartureEntity("gv", "01:22", "01:27"),
                       new DepartureEntity("ledn", "01:40", "01:41"),
                       new DepartureEntity("shl", "01:58", "02:01"),
                       new DepartureEntity("asd", "02:14", "02:17"),
                       new DepartureEntity("ut", "02:51", "02:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "982", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "00:52", "00:52"),
                       new DepartureEntity("dt", "01:05", "01:05"),
                       new DepartureEntity("gv", "01:12", "01:24"),
                       new DepartureEntity("ledn", "01:36", "01:38"),
                       new DepartureEntity("shl", "01:56", "02:00"),
                       new DepartureEntity("asd", "02:14", "02:17"),
                       new DepartureEntity("ut", "02:57", "02:57"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "983", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "00:52", "00:52"),
                       new DepartureEntity("dt", "01:05", "01:05"),
                       new DepartureEntity("gv", "01:12", "01:24"),
                       new DepartureEntity("ledn", "01:36", "01:38"),
                       new DepartureEntity("shl", "01:56", "02:00"),
                       new DepartureEntity("asd", "02:14", "02:17"),
                       new DepartureEntity("ut", "02:57", "02:57"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "984", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "01:02", "01:02"),
                       new DepartureEntity("dt", "01:14", "01:14"),
                       new DepartureEntity("gv", "01:22", "01:23"),
                       new DepartureEntity("ledn", "01:38", "01:40"),
                       new DepartureEntity("asd", "02:14", "02:17"),
                       new DepartureEntity("asb", "02:28", "02:30"),
                       new DepartureEntity("ut", "02:51", "02:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "985", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "01:02", "01:02"),
                       new DepartureEntity("dt", "01:14", "01:14"),
                       new DepartureEntity("gv", "01:22", "01:23"),
                       new DepartureEntity("ledn", "01:36", "01:38"),
                       new DepartureEntity("shl", "01:56", "02:00"),
                       new DepartureEntity("asd", "02:14", "02:15"),
                       new DepartureEntity("ut", "02:51", "02:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "986", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "01:02", "01:02"),
                       new DepartureEntity("dt", "01:14", "01:14"),
                       new DepartureEntity("gv", "01:22", "01:23"),
                       new DepartureEntity("ledn", "01:36", "01:38"),
                       new DepartureEntity("shl", "01:56", "02:00"),
                       new DepartureEntity("asd", "02:14", "02:17"),
                       new DepartureEntity("ut", "02:51", "02:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "987", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "01:02", "01:02"),
                       new DepartureEntity("dt", "01:14", "01:14"),
                       new DepartureEntity("gv", "01:22", "01:27"),
                       new DepartureEntity("ledn", "01:40", "01:41"),
                       new DepartureEntity("shl", "01:58", "02:01"),
                       new DepartureEntity("asd", "02:14", "02:17"),
                       new DepartureEntity("ut", "02:51", "02:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "988", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "01:02", "01:02"),
                       new DepartureEntity("dt", "01:14", "01:14"),
                       new DepartureEntity("gv", "01:22", "01:23"),
                       new DepartureEntity("ledn", "01:36", "01:38"),
                       new DepartureEntity("asd", "02:10", "02:17"),
                       new DepartureEntity("ut", "02:51", "02:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "989", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "01:02", "01:02"),
                       new DepartureEntity("dt", "01:14", "01:14"),
                       new DepartureEntity("gv", "01:22", "01:23"),
                       new DepartureEntity("ledn", "01:38", "01:39"),
                       new DepartureEntity("shl", "01:56", "02:00"),
                       new DepartureEntity("asd", "02:14", "02:17"),
                       new DepartureEntity("ut", "02:51", "02:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "990", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "01:02", "01:02"),
                       new DepartureEntity("dt", "01:14", "01:14"),
                       new DepartureEntity("gv", "01:22", "01:23"),
                       new DepartureEntity("ledn", "01:36", "01:38"),
                       new DepartureEntity("shl", "01:56", "02:00"),
                       new DepartureEntity("asd", "02:14", "02:15"),
                       new DepartureEntity("ut", "02:51", "02:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "991", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "01:02", "01:02"),
                       new DepartureEntity("dt", "01:14", "01:14"),
                       new DepartureEntity("gv", "01:22", "01:27"),
                       new DepartureEntity("ledn", "01:40", "01:41"),
                       new DepartureEntity("shl", "01:58", "02:01"),
                       new DepartureEntity("asd", "02:14", "02:17"),
                       new DepartureEntity("ut", "02:51", "02:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "992", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "01:02", "01:02"),
                       new DepartureEntity("dt", "01:14", "01:14"),
                       new DepartureEntity("gv", "01:22", "01:23"),
                       new DepartureEntity("ledn", "01:36", "01:38"),
                       new DepartureEntity("shl", "01:56", "02:00"),
                       new DepartureEntity("asd", "02:14", "02:17"),
                       new DepartureEntity("ut", "02:51", "02:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "993", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ht", "03:26", "03:26"),
                       new DepartureEntity("ehv", "03:47", "03:47"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "994", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "01:32", "01:32"),
                       new DepartureEntity("gd", "01:50", "01:57"),
                       new DepartureEntity("gv", "02:16", "02:23"),
                       new DepartureEntity("ledn", "02:36", "02:38"),
                       new DepartureEntity("shl", "02:56", "03:00"),
                       new DepartureEntity("asd", "03:14", "03:17"),
                       new DepartureEntity("ut", "03:57", "03:57"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "995", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("rtd", "01:32", "01:32"),
                       new DepartureEntity("gd", "01:50", "01:57"),
                       new DepartureEntity("gv", "02:16", "02:23"),
                       new DepartureEntity("ledn", "02:36", "02:38"),
                       new DepartureEntity("shl", "02:56", "03:00"),
                       new DepartureEntity("asd", "03:14", "03:17"),
                       new DepartureEntity("ut", "03:57", "03:57"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "996", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "00:30", "00:30"),
                       new DepartureEntity("tb", "01:00", "01:02"),
                       new DepartureEntity("bd", "01:18", "01:19"),
                       new DepartureEntity("ddr", "01:40", "01:41"),
                       new DepartureEntity("rtd", "01:55", "02:02"),
                       new DepartureEntity("dt", "02:14", "02:14"),
                       new DepartureEntity("gv", "02:22", "02:23"),
                       new DepartureEntity("ledn", "02:36", "02:38"),
                       new DepartureEntity("shl", "02:56", "03:00"),
                       new DepartureEntity("asd", "03:14", "03:17"),
                       new DepartureEntity("ut", "03:51", "03:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "997", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "00:30", "00:30"),
                       new DepartureEntity("tb", "01:00", "01:02"),
                       new DepartureEntity("bd", "01:18", "01:19"),
                       new DepartureEntity("ddr", "01:40", "01:41"),
                       new DepartureEntity("rtd", "01:55", "02:02"),
                       new DepartureEntity("dt", "02:14", "02:14"),
                       new DepartureEntity("gv", "02:22", "02:23"),
                       new DepartureEntity("ledn", "02:36", "02:38"),
                       new DepartureEntity("shl", "02:56", "03:00"),
                       new DepartureEntity("asd", "03:14", "03:17"),
                       new DepartureEntity("ut", "03:51", "03:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "998", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "00:30", "00:30"),
                       new DepartureEntity("tb", "01:00", "01:02"),
                       new DepartureEntity("bd", "01:18", "01:19"),
                       new DepartureEntity("ddr", "01:40", "01:41"),
                       new DepartureEntity("rtd", "01:55", "02:02"),
                       new DepartureEntity("dt", "02:14", "02:14"),
                       new DepartureEntity("gv", "02:22", "02:23"),
                       new DepartureEntity("ledn", "02:36", "02:38"),
                       new DepartureEntity("shl", "02:56", "03:00"),
                       new DepartureEntity("asd", "03:14", "03:15"),
                       new DepartureEntity("ut", "03:51", "03:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "999", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "00:30", "00:30"),
                       new DepartureEntity("tb", "01:00", "01:02"),
                       new DepartureEntity("bd", "01:18", "01:19"),
                       new DepartureEntity("ddr", "01:40", "01:41"),
                       new DepartureEntity("rtd", "01:55", "02:02"),
                       new DepartureEntity("dt", "02:14", "02:14"),
                       new DepartureEntity("gv", "02:22", "02:23"),
                       new DepartureEntity("ledn", "02:36", "02:38"),
                       new DepartureEntity("shl", "02:56", "03:00"),
                       new DepartureEntity("asd", "03:14", "03:17"),
                       new DepartureEntity("ut", "03:51", "03:51"),
                   }
                },
                new RouteEntity
                {
                   RouteId = "1000", Started = false, Departures = new DepartureEntities
                   {
                       new DepartureEntity("ehv", "00:30", "00:30"),
                       new DepartureEntity("tb", "01:00", "01:02"),
                       new DepartureEntity("bd", "01:18", "01:19"),
                       new DepartureEntity("ddr", "01:40", "01:41"),
                       new DepartureEntity("rtd", "01:55", "02:02"),
                       new DepartureEntity("dt", "02:14", "02:14"),
                       new DepartureEntity("gv", "02:22", "02:23"),
                       new DepartureEntity("ledn", "02:36", "02:38"),
                       new DepartureEntity("shl", "02:56", "03:00"),
                       new DepartureEntity("asd", "03:14", "03:15"),
                       new DepartureEntity("ut", "03:51", "03:51"),
                   }
                },
            };
        }

        #endregion
    }
}
