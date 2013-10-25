#include <iostream>
#include <algorithm>
using namespace std;
int main () {
  int ints[] = {11, 33, 55, 77};
  cout << "The 3! possible permutations with 3 elements:\n";
  do {
    cout << ints[0] <<" "<< ints[1] <<" "<< ints[2]<<" "<<ints[3] << endl;
  } while ( next_permutation (ints,ints+4) );
  return 0;
}
