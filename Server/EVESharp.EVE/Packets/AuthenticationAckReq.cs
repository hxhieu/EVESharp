using EVESharp.Types;
using EVESharp.Types.Collections;
using System;

namespace EVESharp.EVE.Packets
{
    public class AuthenticationAckReq
    {
        private static PyDataType _raw;
        public static implicit operator AuthenticationAckReq (PyDataType packet)
        {
            _raw = packet;
            PyTuple data = packet as PyTuple;

            if (data.Count != 3)
                throw new Exception ($"{nameof (AuthenticationAckReq)} expected tuple to have 3 items but got {data.Count}");
            return new AuthenticationAckReq ();
        }

        public override string ToString ()
        {
            return _raw.ToString ();
        }
    }
}
