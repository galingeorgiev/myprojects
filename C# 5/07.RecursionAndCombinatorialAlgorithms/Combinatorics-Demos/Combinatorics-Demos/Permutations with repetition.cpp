#include <stdio.h>
unsigned mp[100], n = 3;
void print(void)
{ unsigned i;
  for (i = 0; i < n; i++) printf("%u ", mp[i] + 1);
  printf("\n");
}
int r = 4;
void permute(unsigned i)
{  unsigned k;
   if (i >= n) { print(); return; }
   for (k = 0; k < r; k++) {
      mp[i] = k;
      /* if */ permute(i+1);
   }
}
int main () {
  permute(0);
}
