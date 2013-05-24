class Sample {
  void main() {
    int a = 0;
    if (a == 0) {
      Console.WriteLine(0);
    } else {
      Console.WriteLine(1);
    }
    try {
      throw new Exception();
      a++;
    }
    catch {
      a--;
    }
    finally {
      a *= 2;
    }
  }
}