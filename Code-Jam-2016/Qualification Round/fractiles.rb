def gold_test(k, c, s)
	if (c==1 && s < k) || (c * s < k)
		return "IMPOSSIBLE"
	end
	indices = []	
	(1..k).step(c).each do |value|		
		range = []
		value + c - 1 < k ? value + c - 1: k
		if value + c - 1 <= k
			range = (value...value + c).to_a
		else
			(0...c).each do |i|
				range.push(value + i < k ? value + i : k)
			end
		end		
		#puts "range #{range[0]} - #{range[-1]}"
		index = get_index(range,k)
		indices.push(index)
	end
	indices.join(' ')
end

def get_index(choices, k)
	puts "choices #{choices.join(' ')}"
	number = choices.map { |n| n-1 }
	puts number.join(' ')
	puts k
	using_base(number, k) + 1
end

def using_base(number, base)
	current = number.reverse
	result = 0
	(0...number.count).each do |i|
			result +=  current[i] * base**i
	end
	result
end

#choices = [2,1,2]
#puts get_index(choices, 2)

#puts "Case : #{gold_test(2, 3, 2).join(' ')}"
#puts "Case : #{gold_test(1, 1, 1).join(' ')}"
#puts "Case : #{gold_test(2, 1, 1)}"
#puts "Case : #{gold_test(2, 1, 2).join(' ')}"
#puts "Case : #{gold_test(3, 2, 3).join(' ')}"

in_file = ARGV.first

stream = IO.readlines(in_file)
number_of_cases = stream[0].to_i
out_file = open("output.txt", 'w')


(1..number_of_cases).each do |case_number|
	k, c, s = stream[case_number].chomp.split(' ').map(&:to_i)
	#k, c, s = 2, 3, 2
	result = gold_test(k, c, s)
	out_file.puts "Case ##{case_number}: #{result}"
end