class Sample:
	def main():
		a = 0
		if a == 0:
			print (0)
		else:
			print (1)
		try:
			raise Exception('')
			a = a + 1
		except:
			a = a - 1
		else:
			a = a * 2
