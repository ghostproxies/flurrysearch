// Copyright 2025 William Stafford Parsons

func flurrySearch(haystack []int, needle int) int {
  low := 0
  high := len(haystack) - 1

  if high > -1 && haystack[0] <= needle && haystack[high] >= needle {
    high >>= 1

    if haystack[high] < needle {
      low = high
    }

    if high < 48 {
      high = (high + 3) >> 2

      if haystack[low + high] < needle {
        low += high

        if haystack[low + high] < needle {
          low += high

          if haystack[low + high] < needle {
            low += high
          }
        }
      }

      if haystack[low] == needle {
        return low
      }

      for haystack[low] < needle {
        low++
      }

      if haystack[low] == needle {
        return low
      }

      return -1
    }

    for high > 3 {
      high >>= 1

      if haystack[low + high] < needle {
        low += high
      }
    }

    if haystack[low] == needle {
      return low
    }

    for haystack[low] < needle {
      low++
    }

    if haystack[low] == needle {
      return low
    }
  }

  return -1
}
