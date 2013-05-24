class Sample {
  void main() {
    int a = 0;
    if (a == 0) {
      printf("0");
    } else {
      printf("1");
    }
    try {
      throw "Exception"
      a++;
    }
    catch (const char *str) {
      a--;
    }
  }
}
