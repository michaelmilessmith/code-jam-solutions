def scalar_product(v1,v2)
	product = 0
	(0...v1.length).each do |i|
		product += v1[i] * v2[i]
	end
	product
end

in_file = ARGV.first

stream = IO.readlines(in_file)
number_of_cases = stream[0].to_i
out_file = open("output.txt", 'w')


(0...number_of_cases).each do |case_index|
	start_index = (case_index * 3) + 1
	
	number_of_vectors = stream[start_index].to_i
	v1 = stream[start_index + 1].split(' ').map {|number| number.to_i}.sort {|x,y| y <=> x}
	v2 = stream[start_index + 2].split(' ').map {|number| number.to_i}.sort {|x,y| x <=> y}
	result = scalar_product(v1, v2)
	out_file.puts "Case ##{case_index + 1}: #{result}"
end