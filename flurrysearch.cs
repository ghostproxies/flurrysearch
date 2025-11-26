// Copyright 2025 William Stafford Parsons

public static int FlurrySearch(int[] haystack, int needle) {
  int low = 0;
  int high = haystack.Length - 1;

  if (
    high > -1 &&
    haystack[0] <= needle &&
    haystack[high] >= needle
  ) {
    high >>= 1;

    if (haystack[high] < needle) {
      low = high;
    }

    if (high < 48) {
      high = (high + 3) >> 2;

      if (haystack[low + high] < needle) {
        low += high;

        if (haystack[low + high] < needle) {
          low += high;

          if (haystack[low + high] < needle) {
            low += high;
          }
        }
      }

      if (haystack[low] == needle) {
        return low;
      }

      while (haystack[low] < needle) {
        low++;
      }

      if (haystack[low] == needle) {
        return low;
      }

      return -1;
    }

    while (high > 3) {
      high >>= 1;

      if (haystack[low + high] < needle) {
        low += high;
      }
    }

    if (haystack[low] == needle) {
      return low;
    }

    while (haystack[low] < needle) {
      low++;
    }

    if (haystack[low] == needle) {
      return low;
    }
  }

  return -1;
}
