// lifted null binary operators

using System;

class C
{
	public static int Main ()
	{
		bool v;
		v = (true & null) == null;
		if (!v)
			return 1;

		v = (false & null) != null;
		if (!v)
			return 2;
		
		v = (null & true) == null;
		if (!v)
			return 3;

		v = (null & false) != null;
		if (!v)
			return 4;

		v = (true | null) == null;
		if (v != false)
			return 11;

		v = (false | null) != null;
		if (v != false)
			return 12;

		v = (null | true) == null;
		if (v != false)
			return 13;

		v = (null | false) != null;
		if (v != false)
			return 14;
		
		v = (null & 1) == null;
		if (v != true)
			return 20;
		
		v = (null & 0) != null;
		if (v != false)
			return 21;

		bool? a = false;
		bool? b = true;

		if ((a & null) != false)
			return 50;

		if ((b & null) != null)
			return 51;
		
		if ((null & a) != false)
			return 52;
		
		if ((null & b) != null)
			return 53;

		if ((a & true) != false)
			return 54;
		
		if ((true & a) != false)
			return 55;

		if ((a | null) != null)
			return 60;

		if ((b | null) != true)
			return 61;
		
		if ((null | a) != null)
			return 62;
		
		if ((null | b) != true)
			return 63;
		
		if ((a | true) != true)
			return 64;
		
		if ((true | a) != true)
			return 65;

		var b4 = true;
		if ((b4 & null) != null)
			return 100;

		if ((null & b4) != null)
			return 101;

		if ((b4 | null) != true)
			return 102;

		if ((null | b4) != true)
			return 103;

		bool? x_n = null;
		bool? x_f = false;
		bool? x_t = true;

		bool? res;
		res = null & x_n;
		if (res.HasValue)
			return 201;

		res = null & x_t;
		if (res.HasValue)
			return 202;

		res = null & x_f;
		if (res.Value != false)
			return 203;

		res = null | x_n;
		if (res.HasValue)
			return 204;

		res = null | x_t;
		if (res.Value != true)
			return 205;

		res = null | x_f;
		if (res.HasValue)
			return 206;
		
		return 0;
	}
	
	// This does not look right but C# spec needs tidying up to special case it
	void BrokenLiftedNull ()
	{
		int i = 44;
		int? u = null;
		i <<= u;
		i <<= null;
	}
}