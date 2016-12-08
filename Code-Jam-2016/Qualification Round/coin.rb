def create_jamcoin(n)
	jamcoin = [1]
	(1...n -1).each do |i|
		jamcoin.push(rand(2))
	end
	jamcoin.push(1)	
	jamcoin = jamcoin.join.to_i
	if !verify_odd_base(jamcoin)
		index = jamcoin.to_s.index('0')
		jamcoin += 10**(jamcoin.to_s.size - 1 - index)
	end
	jamcoin
end

def verify_jamcoin(jamcoin)
	dividers = []
	(2..10).each do |base|
		#puts "base: #{base}"
		number = using_base(jamcoin, base)
		#puts "number: #{number}" 
		prime = true
		(2..10).each do |divide|
			if number % divide == 0
				prime = false
				dividers.push(divide)
				#puts "divide: #{divide}"
				break
			end
		end
		if prime
			return false
		end
	end
	return true, dividers
end

def verify_odd_base(jamcoin)
	one_count = jamcoin.to_s.scan(/(?=#{1})/).count
	one_count.even?
end

def using_base(number, base)
	current = number.to_s.chars.reverse
	result = 0
	(0...number.to_s.size).each do |i|
		if current[i] == '1'
			result += base**i
		end		
	end
	result
end

in_file = ARGV.first

#stream = IO.readlines(in_file)
#number_of_cases = stream[0].to_i
out_file = open("output.txt", 'w')
out_file.puts "Case #1:"

#n,j = stream[1].split(' ').map(&:to_i)
n,j = 32,500
result = []
display = []
(0...j).each do |i|
jamcoin = 0
dividers = []
jamcoin_yes = false
until jamcoin_yes
	#puts "Attempt"
	jamcoin = create_jamcoin(n)
	#puts jamcoin
	if !result.include? jamcoin	
		ver, dividers = verify_jamcoin(jamcoin)
	#puts ver
		jamcoin_yes = ver
	#puts "End"
	else 
		puts "Clash #{jamcoin}"
	end
end
result.push(jamcoin)
display.push("#{jamcoin} #{dividers.join(' ')}")
out_file.puts("#{jamcoin} #{dividers.join(' ')}")
end
puts display
#puts using_base(110111, 3)