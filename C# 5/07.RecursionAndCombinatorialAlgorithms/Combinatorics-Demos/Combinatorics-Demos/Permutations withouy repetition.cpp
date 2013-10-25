#include <stdio.h>
char used[100]; unsigned mp[100], n = 4;
void print(void)
{ unsigned i;
  for (i = 0; i < n; i++) printf("%u ", mp[i] + 1);
  printf("\n");
}
void permute(unsigned i)
{  unsigned k;
   if (i >= n) { print(); return; }
   for (k = 0; k < n; k++) {
      if (!used[k]) {
         used[k] = 1;
         mp[i] = k;
         /* if */ permute(i+1);
         used[k] = 0;
      }
   }
}
int main()
{
    permute(0);
    return 0;
}
