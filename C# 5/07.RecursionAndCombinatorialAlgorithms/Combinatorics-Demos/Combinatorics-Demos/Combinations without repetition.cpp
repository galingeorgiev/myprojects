#include <stdio.h>
int n = 5, k = 3, mp[20];
void print(unsigned length)
{  for (int i = 0; i < length; i++) printf("%u ", mp[i]);
   printf("\n");
}
void komb(unsigned i, unsigned after)
{  unsigned j;
   if (i > k) return;
   for (j = after + 1; j <= n; j++) {
      mp[i - 1] = j;
      if (i == k) print(i);
      komb(i + 1, j);
  }
}
int main(void) {
   printf("C(%u,%u): \n", n, k);
   komb(1, 0);
   return 0;
}
