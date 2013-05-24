class Sample
  def main()
    a = 0
    if a = 0
      p '0'
    else
      p '1'
    end
    begin
      raise
      a += 1
    rescue
      a -= 1
    ensure
      a *= 2
    end
  end
end