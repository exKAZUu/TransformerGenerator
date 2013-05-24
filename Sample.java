class Sample {
  void main() {
    int a = 0;
    if (a == 0) {
      System.out.println(0);
    } else {
      System.out.println(1);
    }
    try {
      throw new Exception();
      a++;
    }
    catch (Exception e) {
      a--;
    }
    finally {
      a *= 2;
    }
  }
}