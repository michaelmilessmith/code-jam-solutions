def find_02468(s)
	result = {}
	result[0] = s.count('Z')
	result[2] = s.count('W')
	result[4] = s.count('U')
	result[6] = s.count('X')
	result[8] = s.count('G')
	result
end

def find_1357_after_02468_removed(s)
	result = {}
	result[1] = s.count('O')
	result[3] = s.count('T')
	result[5] = s.count('F')
	result[7] = s.count('S')
	result
end

def remove_02468(s, counts)
	s_array = s.chars
	(0..8).step(2).each do |number|
		if counts[number] > 0		
			name = number_to_name(number) * counts[number]
			name.chars.each do |char|
				index = s_array.index(char)
				s_array.delete_at(index)
			end
		end
	end
	s_array.join
end

def remove_1357(s, counts)
	s_array = s.chars
	(1..7).step(2).each do |number|
		if counts[number] > 0		
			name = number_to_name(number) * counts[number]
			name.chars.each do |char|
				index = s_array.index(char)
				s_array.delete_at(index)
			end
		end
	end
	s_array.join
end

def number_to_name(number)
	names = {
			0 => "ZERO",
			1 => "ONE",
			2 => "TWO",
			3 => "THREE",
			4 => "FOUR",
			5 => "FIVE",
			6 => "SIX",
			7 => "SEVEN",
			8 => "EIGHT",
			9 => "NINE",
			}
	names[number]
end

def count_hash_to_number(hash)
	result = ""
	(0..9).each do |number|
		result += number.to_s * hash[number]
	end
	result
end

def solve(s)
	amount_02468s = find_02468(s)
	removed_02468s = remove_02468(s, amount_02468s)
	amount_1357s = find_1357_after_02468_removed(removed_02468s)
	removed_012345678s = remove_1357(removed_02468s, amount_1357s)
	amount_12345678s = amount_02468s.merge(amount_1357s)
	
	count_9 = removed_012345678s.length / 4
	amount_12345678s[9] = count_9
	
	count_hash_to_number(amount_12345678s)
end

#result = solve("ETHER")
#puts result

in_file = ARGV.first

stream = IO.readlines(in_file)
number_of_cases = stream[0].to_i
out_file = open("output.txt", 'w')


(1..number_of_cases).each do |case_number|
	s = stream[case_number].chomp
	result = solve(s)
	out_file.puts "Case ##{case_number}: #{result}"
end